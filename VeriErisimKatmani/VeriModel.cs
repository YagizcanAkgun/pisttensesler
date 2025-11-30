using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriErisimKatmani
{
    public class VeriModel
    {

        SqlConnection con;
        SqlCommand cmd;

        public VeriModel()
        {
            con = new SqlConnection(BaglantiYollari.BaglantiYolu);
            cmd = con.CreateCommand();
        }
        #region Yönetici Metootları
        public Yonetici YoneticiGiris(string mail, string sifre)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Yoneticiler WHERE Mail = @m AND Sifre = @s";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@m", mail);
                cmd.Parameters.AddWithValue("@s", sifre);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi != 0)
                {
                    cmd.CommandText = "SELECT Y.ID, Y.YoneticiTurID, YT.Isim, Y.Isim, Y.Soyisim, Y.Mail, Y.Sifre, Y.KullaniciAdi, Y.AktifMi FROM Yoneticiler AS Y JOIN YoneticiTurleri AS YT ON Y.YoneticiTurID= YT.ID WHERE Y.Mail=@m AND Y.Sifre=@s";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@m", mail);
                    cmd.Parameters.AddWithValue("@s", sifre);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Yonetici y = new Yonetici();
                    while (reader.Read())
                    {
                        y.ID = reader.GetInt32(0);
                        y.YoneticiTurID = reader.GetInt32(1);
                        y.YoneticiTur = reader.GetString(2);
                        y.Isim = reader.GetString(3);
                        y.Soyisim = reader.GetString(4);
                        y.Mail = reader.GetString(5);
                        y.Sifre = reader.GetString(6);
                        y.KullaniciAdi = reader.GetString(7);
                        y.AktifMi = reader.GetBoolean(8);

                    }
                    return y;
                }
                return null;
            }
            catch { return null; }
            finally { con.Close(); }
        }
        #endregion

        #region Kategori Metotları

        public bool KategoriEkle(Kategori kat)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Kategoriler(Isim,AktifMi) VALUES(@isim,@aktifMi)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", kat.Isim);
                cmd.Parameters.AddWithValue("@aktifMi", kat.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally
            {
                con.Close();
            }
        }

        public List<Kategori> KategoriListele()
        {
            List<Kategori> kategoriler = new List<Kategori>();
            try
            {
                cmd.CommandText = "SELECT ID, Isim, AktifMi FROM Kategoriler";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Kategori kat = new Kategori();
                    kat.ID = reader.GetInt32(0);
                    kat.Isim = reader.GetString(1);
                    kat.Durum = reader.GetBoolean(2);
                    if (kat.Durum)
                    {
                        kat.DurumStr = "Aktif";
                    }
                    else
                    {
                        kat.DurumStr = "Pasif";
                    }

                    kategoriler.Add(kat);
                }
                return kategoriler;
            }
            catch { return null; }
            finally { con.Close(); }
        }
        public List<Kategori> AktifKategoriListele()
        {
            List<Kategori> kategoriler = new List<Kategori>();
            try
            {
                cmd.CommandText = "SELECT ID, Isim, AktifMi FROM Kategoriler WHERE AktifMi = 1";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Kategori kat = new Kategori();
                    kat.ID = reader.GetInt32(0);
                    kat.Isim = reader.GetString(1);
                    kat.Durum = reader.GetBoolean(2);
                    if (kat.Durum)
                    {
                        kat.DurumStr = "Aktif";
                    }
                    else
                    {
                        kat.DurumStr = "Pasif";
                    }

                    kategoriler.Add(kat);
                }
                return kategoriler;
            }
            catch { return null; }
            finally { con.Close(); }
        }

        public void KategoriDurumDegistir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT AktifMi FROM Kategoriler WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                bool durum = Convert.ToBoolean(cmd.ExecuteScalar());
                cmd.CommandText = "UPDATE Kategoriler Set AktifMi = @d WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@d", !durum);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

        public bool KategoriDuzenle(Kategori kat)
        {
            try
            {
                cmd.CommandText = "UPDATE Kategoriler SET Isim = @isim, AktifMi=@aktifmi WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", kat.ID);
                cmd.Parameters.AddWithValue("@isim", kat.Isim);
                cmd.Parameters.AddWithValue("@aktifmi", kat.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public void KategoriSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Kategoriler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

        public Kategori kategoriGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT ID,Isim,AktifMi FROM Kategoriler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Kategori kat = null;
                while (reader.Read())
                {
                    kat = new Kategori();
                    kat.ID = reader.GetInt32(0);
                    kat.Isim = reader.GetString(1);
                    kat.Durum = reader.GetBoolean(2);
                }
                return kat;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public int KategoriSayisi()
        {
            using (SqlConnection conn = new SqlConnection(BaglantiYollari.BaglantiYolu))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Kategoriler", conn);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        #endregion

        #region Makale Metotları

        public bool MakaleEkle(Makale mak)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Makaleler(YazarID,KategoriID,Baslik,Icerik,Ozet,KapakResim,GoruntulemeSayi,EklemeTarihi,SilinMisMi,AktifMi) VALUES(@yazarID,@kategoriID,@baslik,@icerik,@ozet,@kapakResim,@goruntulemeSayi,@eklemeTarihi,@silinMisMi,@aktifMi)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@yazarID", mak.YazarID);
                cmd.Parameters.AddWithValue("@kategoriID", mak.KategoriID);
                cmd.Parameters.AddWithValue("@baslik", mak.Baslik);
                cmd.Parameters.AddWithValue("@icerik", mak.Icerik);
                cmd.Parameters.AddWithValue("@ozet", mak.Ozet);
                cmd.Parameters.AddWithValue("@kapakResim", mak.KapakResim);
                cmd.Parameters.AddWithValue("@goruntulemeSayi", mak.GoruntulemeSayi);
                cmd.Parameters.AddWithValue("@eklemeTarihi", mak.EklemeTarihi);
                cmd.Parameters.AddWithValue("@silinMisMi", mak.SilinmisMi);
                cmd.Parameters.AddWithValue("@aktifMi", mak.AktifMi);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Silinme Durumuna göre Makaleleri listeler
        /// </summary>
        /// <param name="silinmeDurum">
        /// 1 silinmiş olan makaleleri listeler
        /// 0 silinmemiş olan makaleleri listeler
        /// -1 tüm makaleleri listeler
        /// </param>
        /// <returns>Makale Koleksiyonu döndürür</returns>
        public List<Makale> MakaleListele(int silinmeDurum)
        {
            List<Makale> makaleler = new List<Makale>();
            try
            {
                string Query = "SELECT M.ID,M.YazarID, Y.KullaniciAdi,M.KategoriID, K.Isim, M.Baslik,M.Icerik,M.Ozet,M.KapakResim,M.GoruntulemeSayi,M.EklemeTarihi,M.SilinmisMi,M.AktifMi FROM Makaleler AS M JOIN Yoneticiler AS Y ON M.YazarID = Y.ID JOIN Kategoriler AS K ON M.KategoriID = K.ID";
                if (silinmeDurum == -1)
                {
                    cmd.CommandText = Query;
                }
                else if (silinmeDurum == 1)
                {
                    cmd.CommandText = Query + " WHERE M.SilinmisMi = 1";
                }
                else if (silinmeDurum == 0)
                {
                    cmd.CommandText = Query + " WHERE M.SilinmisMi = 0";
                }
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Makale mak = new Makale();
                    mak.ID = reader.GetInt32(0);
                    mak.YazarID = reader.GetInt32(1);
                    mak.Yazar = reader.GetString(2);
                    mak.KategoriID = reader.GetInt32(3);
                    mak.KategoriAdi = reader.GetString(4);
                    mak.Baslik = reader.GetString(5);
                    if (!reader.IsDBNull(6)) { mak.Icerik = reader.GetString(6); }
                    if (!reader.IsDBNull(7)) { mak.Ozet = reader.GetString(7); }
                    mak.KapakResim = reader.GetString(8);
                    mak.GoruntulemeSayi = reader.GetInt32(9);
                    mak.EklemeTarihi = reader.GetDateTime(10);
                    mak.EklemeTarihiStr = mak.EklemeTarihi.ToShortDateString();
                    mak.SilinmisMi = reader.GetBoolean(11);
                    mak.AktifMi = reader.GetBoolean(12);
                    mak.AktifMiStr = reader.GetBoolean(12) ? "Aktif" : "Pasif";
                    makaleler.Add(mak);
                }
                return makaleler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Makale> AktifMakaleleriListele()
        {
            List<Makale> makaleler = new List<Makale>();
            try
            {
                cmd.CommandText = @"SELECT M.ID,M.YazarID, Y.KullaniciAdi,M.KategoriID,
                                   K.Isim, M.Baslik,M.Icerik,M.Ozet,M.KapakResim,
                                   M.GoruntulemeSayi,M.EklemeTarihi,M.SilinmisMi,M.AktifMi
                            FROM Makaleler AS M
                            JOIN Yoneticiler AS Y ON M.YazarID = Y.ID
                            JOIN Kategoriler AS K ON M.KategoriID = K.ID
                            WHERE M.SilinmisMi = 0 AND M.AktifMi = 1";

                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Makale mak = new Makale();
                    mak.ID = reader.GetInt32(0);
                    mak.YazarID = reader.GetInt32(1);
                    mak.Yazar = reader.GetString(2);
                    mak.KategoriID = reader.GetInt32(3);
                    mak.KategoriAdi = reader.GetString(4);
                    mak.Baslik = reader.GetString(5);
                    if (!reader.IsDBNull(6)) mak.Icerik = reader.GetString(6);
                    if (!reader.IsDBNull(7)) mak.Ozet = reader.GetString(7);
                    mak.KapakResim = reader.GetString(8);
                    mak.GoruntulemeSayi = reader.GetInt32(9);
                    mak.EklemeTarihi = reader.GetDateTime(10);
                    mak.EklemeTarihiStr = mak.EklemeTarihi.ToShortDateString();
                    mak.SilinmisMi = reader.GetBoolean(11);
                    mak.AktifMi = reader.GetBoolean(12);
                    mak.AktifMiStr = mak.AktifMi ? "Aktif" : "Pasif";
                    makaleler.Add(mak);
                }
                return makaleler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }


        public Makale MakaleGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT M.ID,M.YazarID, Y.KullaniciAdi,M.KategoriID, K.Isim, M.Baslik,M.Icerik,M.Ozet,M.KapakResim,M.GoruntulemeSayi,M.EklemeTarihi,M.SilinmisMi,M.AktifMi FROM Makaleler AS M JOIN Yoneticiler AS Y ON M.YazarID = Y.ID JOIN Kategoriler AS K ON M.KategoriID = K.ID WHERE M.ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Makale mak = null;
                while (reader.Read())
                {
                    mak = new Makale();
                    mak.ID = reader.GetInt32(0);
                    mak.YazarID = reader.GetInt32(1);
                    mak.Yazar = reader.GetString(2);
                    mak.KategoriID = reader.GetInt32(3);
                    mak.KategoriAdi = reader.GetString(4);
                    mak.Baslik = reader.GetString(5);
                    if (!reader.IsDBNull(6)) { mak.Icerik = reader.GetString(6); }
                    if (!reader.IsDBNull(7)) { mak.Ozet = reader.GetString(7); }
                    mak.KapakResim = reader.GetString(8);
                    mak.GoruntulemeSayi = reader.GetInt32(9);
                    mak.EklemeTarihi = reader.GetDateTime(10);
                    mak.EklemeTarihiStr = mak.EklemeTarihi.ToShortDateString();
                    mak.SilinmisMi = reader.GetBoolean(11);
                    mak.AktifMi = reader.GetBoolean(12);
                    mak.AktifMiStr = reader.GetBoolean(12) ? "Aktif" : "Pasif";
                }
                return mak;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool MakaleDuzenle(Makale mak)
        {
            try
            {
                cmd.CommandText = "UPDATE Makaleler SET Baslik = @baslik, KategoriID = @kategoriId, Ozet=@ozet,Icerik=@icerik, KapakResim=@kapakresim, AktifMi=@aktifmi WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", mak.ID);
                cmd.Parameters.AddWithValue("@baslik", mak.Baslik);
                cmd.Parameters.AddWithValue("@kategoriId", mak.KategoriID);
                cmd.Parameters.AddWithValue("@ozet", mak.Ozet);
                cmd.Parameters.AddWithValue("@icerik", mak.Icerik);
                cmd.Parameters.AddWithValue("@kapakresim", mak.KapakResim);
                cmd.Parameters.AddWithValue("@aktifmi", mak.AktifMi);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public void MakaleDurumDegistir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT AktifMi FROM Makaleler WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                bool durum = Convert.ToBoolean(cmd.ExecuteScalar());
                con.Close(); 

                cmd.CommandText = "UPDATE Makaleler SET AktifMi = @d WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@d", !durum);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }

        }

        public int MakaleSayisi()
        {
            using (SqlConnection conn = new SqlConnection(BaglantiYollari.BaglantiYolu))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Makaleler", conn);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public void MakaleSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Makaleler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }


        #endregion

        #region Üye Metotları

        public bool KayitOl(Uye u)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Uyeler(Isim, Soyisim, KullaniciAdi, Mail, Sifre, AktifMi) VALUES (@isim, @soyisim, @kullaniciAdi, @mail, @sifre, @aktifMi)";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", u.Isim);
                cmd.Parameters.AddWithValue("@soyisim", u.Soyisim);
                cmd.Parameters.AddWithValue("@kullaniciAdi", u.KullaniciAdi);
                cmd.Parameters.AddWithValue("@mail", u.Mail);
                cmd.Parameters.AddWithValue("@sifre", u.sifre);
                cmd.Parameters.AddWithValue("@aktifMi", u.AktifMi);

                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public Uye GirisYap(string mail, string sifre)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Uyeler WHERE Mail = @m AND Sifre = @s";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@m", mail);
                cmd.Parameters.AddWithValue("@s", sifre);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi != 0)
                {
                    cmd.CommandText = "SELECT ID,Isim,Soyisim,KullaniciAdi,Mail,Sifre,AktifMi FROM Uyeler WHERE Mail=@m AND Sifre=@s";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@m", mail);
                    cmd.Parameters.AddWithValue("@s", sifre);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Uye u = new Uye();
                    while (reader.Read())
                    {
                        u.ID = reader.GetInt32(0);
                        u.Isim = reader.GetString(1);
                        u.Soyisim = reader.GetString(2);
                        u.KullaniciAdi = reader.GetString(3);
                        u.Mail = reader.GetString(4);
                        u.sifre = reader.GetString(5);
                        u.AktifMi = reader.GetBoolean(6);
                    }
                    return u;
                }
                return null;
            }
            catch { return null; }
            finally { con.Close(); }
        }

        /// <summary>
        /// Tüm üyeleri listeler (aktif ve pasif ayrımıyla)
        /// </summary>
        /// <returns>Uye Koleksiyonu döndürür</returns>
        public List<Uye> UyeListele()
        {
            List<Uye> uyeler = new List<Uye>();
            try
            {
                string query = "SELECT ID, Isim, Soyisim, KullaniciAdi, Mail, AktifMi FROM Uyeler";
                cmd.CommandText = query;
                cmd.Parameters.Clear();

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Uye uye = new Uye();
                    uye.ID = reader.GetInt32(0);
                    uye.Isim = reader.GetString(1);
                    uye.Soyisim = reader.GetString(2);
                    uye.KullaniciAdi = reader.GetString(3);
                    uye.Mail = reader.GetString(4);
                    uye.AktifMi = reader.GetBoolean(5);
                    uye.AktifMiStr = uye.AktifMi ? "Aktif" : "Pasif";

                    uyeler.Add(uye);
                }

                return uyeler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public void UyeDurumDegistir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT AktifMi FROM Uyeler WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                bool durum = Convert.ToBoolean(cmd.ExecuteScalar());

                cmd.CommandText = "UPDATE Uyeler SET AktifMi = @d WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@d", !durum);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Son adet kadar üyeyi listeler
        /// </summary>
        /// <param name="adet">Kaç adet üye getirilecek</param>
        /// <returns>Üye listesi döndürür</returns>
        public List<Uye> SonUyeler(int adet)
        {
            List<Uye> uyeler = new List<Uye>();

            try
            {
                string query = $@"
            SELECT TOP ({adet}) ID, Isim, Soyisim, KullaniciAdi, Mail, sifre, AktifMi
            FROM Uyeler
            ORDER BY ID DESC";

                cmd.CommandText = query;
                cmd.Parameters.Clear();

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Uye uye = new Uye();
                    uye.ID = reader.GetInt32(0);
                    uye.Isim = reader.GetString(1);
                    uye.Soyisim = reader.GetString(2);
                    uye.KullaniciAdi = reader.GetString(3);
                    uye.Mail = reader.GetString(4);
                    uye.sifre = reader.GetString(5);
                    uye.AktifMi = reader.GetBoolean(6);
                    uye.AktifMiStr = uye.AktifMi ? "Aktif" : "Pasif";

                    uyeler.Add(uye);
                }

                return uyeler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public int UyeSayisi()
        {
            using (SqlConnection conn = new SqlConnection(BaglantiYollari.BaglantiYolu))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Uyeler", conn);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        #endregion

        #region Yorum Metotları

        public bool YorumYap(Yorum y)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Yorumlar (MakaleID,UyeID,Icerik,Tarih,Yayinla) VALUES(@makaleID,@uyeID,@icerik,@tarih,@yayinla)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@makaleID", y.MakaleID);
                cmd.Parameters.AddWithValue("@uyeID", y.UyeID);
                cmd.Parameters.AddWithValue("@icerik", y.Icerik);
                cmd.Parameters.AddWithValue("@tarih", y.Tarih);
                cmd.Parameters.AddWithValue("@yayinla", y.Yayinla);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Yorum> OnayliMakaleYorumlari(int MakaleID)
        {
            List<Yorum> yorumlar = new List<Yorum>();
            try
            {
                cmd.CommandText = "SELECT Y.ID, Y.MakaleID, Y.UyeID, U.KullaniciAdi, Y.Icerik, Y.Tarih, Y.Yayinla FROM Yorumlar AS Y JOIN Uyeler AS U ON Y.UyeID=U.ID WHERE Y.MakaleID = @id AND Y.Yayinla = 1";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", MakaleID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yorum y = new Yorum();
                    y.ID = reader.GetInt32(0);
                    y.MakaleID = reader.GetInt32(1);
                    y.UyeID = reader.GetInt32(2);
                    y.Uye = reader.GetString(3);
                    y.Icerik = reader.GetString(4);
                    y.Tarih = reader.GetDateTime(5);
                    y.TarihStr = y.Tarih.ToShortDateString();
                    y.Yayinla = reader.GetBoolean(6);
                    y.YayinlaStr = y.Yayinla ? "Yayında" : "Engelli";
                    yorumlar.Add(y);

                }
                return yorumlar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Onay durumuna göre yorumları listeler
        /// </summary>
        /// <param name="yayinDurum">
        /// 1 → onaylı yorumları listeler
        /// 0 → onaylanmamış yorumları listeler
        /// -1 → tüm yorumları listeler
        /// </param>
        /// <returns>Yorum koleksiyonu döndürür</returns>
        public List<Yorum> YorumListele(int yayinDurum = 0)
        {
            List<Yorum> yorumlar = new List<Yorum>();
            try
            {
                string query = @"SELECT y.ID, y.MakaleID, y.UyeID, u.KullaniciAdi AS Uye, y.Icerik, y.Tarih, y.Yayinla
                         FROM Yorumlar AS y
                         LEFT JOIN Uyeler AS u ON y.UyeID = u.ID";

                if (yayinDurum == 0)
                    cmd.CommandText = query + " WHERE y.Yayinla = 0 ORDER BY y.Tarih DESC";
                else if (yayinDurum == 1)
                    cmd.CommandText = query + " WHERE y.Yayinla = 1 ORDER BY y.Tarih DESC";
                else
                    cmd.CommandText = query + " ORDER BY y.Tarih DESC";

                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yorum y = new Yorum();
                    y.ID = reader.GetInt32(0);
                    y.MakaleID = reader.GetInt32(1);
                    y.UyeID = reader.GetInt32(2);
                    y.Uye = reader.IsDBNull(3) ? "Ziyaretçi" : reader.GetString(3);
                    y.Icerik = reader.GetString(4);
                    y.Tarih = reader.GetDateTime(5);
                    y.TarihStr = y.Tarih.ToString("dd.MM.yyyy HH:mm");
                    y.Yayinla = reader.GetBoolean(6);
                    y.YayinlaStr = y.Yayinla ? "Aktif" : "Beklemede";

                    yorumlar.Add(y);
                }
                reader.Close();
                return yorumlar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// Yorumun Yayinla durumunu 1 yapar (onaylar)
        /// </summary>
        /// <param name="yorumID">Onaylanacak yorum ID</param>
        public void YorumOnayla(int yorumID)
        {
            try
            {
                cmd.CommandText = "UPDATE Yorumlar SET Yayinla = 1 WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", yorumID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

        public void YorumDurumDegistir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT Yayinla FROM Yorumlar WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                bool durum = Convert.ToBoolean(cmd.ExecuteScalar());

                cmd.CommandText = "UPDATE Yorumlar SET Yayinla = @d WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@d", !durum);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }
        /// <summary>
        /// Son adet kadar yorumu listeler
        /// </summary>
        /// <param name="adet">kaç adet yorum getirilecek</param>
        /// <returns>Yorum listesi döndürür</returns>
        public List<Yorum> SonYorumlar(int adet)
        {
            List<Yorum> yorumlar = new List<Yorum>();

            try
            {
                string query = @"
            SELECT TOP(@adet) Y.ID, Y.MakaleID, Y.UyeID, U.KullaniciAdi, Y.Icerik, Y.Tarih, Y.Yayinla
            FROM Yorumlar Y
            INNER JOIN Uyeler U ON Y.UyeID = U.ID
            ORDER BY Y.Tarih DESC";

                cmd.CommandText = query;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@adet", adet);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Yorum y = new Yorum();
                    y.ID = reader.GetInt32(0);
                    y.MakaleID = reader.GetInt32(1);
                    y.UyeID = reader.GetInt32(2);
                    y.Uye = reader.GetString(3);
                    y.Icerik = reader.GetString(4);
                    y.Tarih = reader.GetDateTime(5);
                    y.TarihStr = y.Tarih.ToString("dd.MM.yyyy HH:mm");
                    y.Yayinla = reader.GetBoolean(6);
                    y.YayinlaStr = y.Yayinla ? "Yayınla" : "Yayınlanmadı";

                    yorumlar.Add(y);
                }

                return yorumlar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public int YorumSayisi()
        {
            using (SqlConnection conn = new SqlConnection(BaglantiYollari.BaglantiYolu))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Yorumlar", conn);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        #endregion
    }
}
