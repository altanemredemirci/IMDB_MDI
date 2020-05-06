using MetroFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odev_1
{
    public class DataAccessLayer
    {
        SqlConnection connect, conn;
        SqlDataReader reader;
        int EKS = 0;
        //Dictionary<string, int> myDic = ((Role[])Enum.GetValues(typeof(Role))).ToDictionary(k => k.ToString(), v => (int)v);
        public DataAccessLayer()
        {
            connect = new SqlConnection("Server=.;Database=IMDBFULL;uid=sa;pwd=9117");
            connect.Open();
            conn = new SqlConnection("Server=.;Database=IMDBFULL;uid=sa;pwd=9117");
            conn.Open();
        }
        public Movie DBControl(Movie movie)
        {
            SqlCommand cmmd = new SqlCommand("Select * from Movies where ImdbId=@ImdbID", connect);
            cmmd.Parameters.Add("@ImdbID", SqlDbType.NVarChar).Value = movie.ImdbId;
            reader = cmmd.ExecuteReader();
            if (reader.HasRows)
            {
                Movie film = new Movie();
                while (reader.Read())
                {
                    film.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                    film.Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                    film.Description = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                    film.Raiting = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                    film.ImdbId = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                    film.Poster = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                }
                reader.Close();
                SqlCommand moviecast = new SqlCommand("SP_MovieCast", connect);
                moviecast.CommandType = CommandType.StoredProcedure;
                moviecast.Parameters.Add("@movie_Id", SqlDbType.Int).Value = film.ID;
                reader = moviecast.ExecuteReader();
                while (reader.Read())
                {
                    Cast cast = new Cast();
                    cast.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                    cast.Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                    cast.ImdbId = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);

                    SqlCommand castrole = new SqlCommand("SP_CastRole", conn);
                    castrole.CommandType = CommandType.StoredProcedure;
                    castrole.Parameters.Add("@cast_Id", SqlDbType.Int).Value = cast.ID;
                    castrole.Parameters.Add("@movie_Id", SqlDbType.Int).Value = film.ID;
                    SqlDataReader castrolereader = castrole.ExecuteReader();
                    while (castrolereader.Read())
                    {
                        Role role = new Role();
                        role.RoleName = castrolereader.IsDBNull(0) ? string.Empty : castrolereader.GetString(0);
                        cast.Roles.Add(role);
                    }
                    castrolereader.Close();
                    film.Casts.Add(cast);
                }
                reader.Close();
                SqlCommand movieimage = new SqlCommand("SP_MovieImage", connect);
                movieimage.CommandType = CommandType.StoredProcedure;
                movieimage.Parameters.Add("@movie_Id", SqlDbType.Int).Value = film.ID;
                reader = movieimage.ExecuteReader();
                while (reader.Read())
                {
                    film.Images.Add(reader.IsDBNull(0) ? string.Empty : reader.GetString(0));
                }
                reader.Close();
                if (film.Casts.Count < 1)
                {
                    return null;
                }
                return film;
            }

            else
            {
                reader.Close();
                return null;
            }
        }
        public void MovieSave(Movie movie)
        {
            SqlCommand cmd = new SqlCommand("SP_MovieSave", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = movie.Name == null ? string.Empty : movie.Name;
            cmd.Parameters.Add("@desc", SqlDbType.NVarChar).Value = movie.Description == null ? string.Empty : movie.Description;
            cmd.Parameters.Add("@rating", SqlDbType.NVarChar).Value = movie.Raiting == null ? string.Empty : movie.Raiting;
            cmd.Parameters.Add("@imdbId", SqlDbType.NVarChar).Value = movie.ImdbId == null ? string.Empty : movie.ImdbId;
            cmd.Parameters.Add("@poster", SqlDbType.NVarChar).Value = movie.Poster == null ? string.Empty : movie.Poster;

            EKS = cmd.ExecuteNonQuery();
            if (EKS < 1)
            {
                MessageBox.Show("Error");
            }
            foreach (Cast cast in movie.Casts)
            {
                SqlCommand castcntrl = new SqlCommand("Select ID from Casts where ImdbId=@ImdbID", connect);
                castcntrl.Parameters.Add("ImdbID", SqlDbType.NVarChar).Value = cast.ImdbId;
                object id = castcntrl.ExecuteScalar();
                if (id == null)
                {
                    SqlCommand castcmd = new SqlCommand("SP_CastSave", connect);
                    castcmd.CommandType = CommandType.StoredProcedure;
                    castcmd.Parameters.Add("@ImdbId", SqlDbType.NVarChar).Value = cast.ImdbId;
                    castcmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = cast.Name;
                    castcmd.Parameters.Add("@born", SqlDbType.NVarChar).Value = cast.Born == null ? string.Empty : cast.Born;
                    castcmd.Parameters.Add("@died", SqlDbType.NVarChar).Value = cast.Died == null ? string.Empty : cast.Died;
                    castcmd.Parameters.Add("@desc", SqlDbType.NVarChar).Value = cast.Description == null ? string.Empty : cast.Description;
                    castcmd.Parameters.Add("@profileImage", SqlDbType.NVarChar).Value = cast.ProfileImage == null ? string.Empty : cast.ProfileImage;
                    castcmd.Parameters.Add("@otherPhotos", SqlDbType.NVarChar).Value = cast.OtherPhotos == null ? string.Empty : cast.OtherPhotos;
                    EKS = castcmd.ExecuteNonQuery();
                    if (EKS < 1)
                    {
                        MessageBox.Show("Error");
                    }
                }

                SqlCommand dbmovie = new SqlCommand("Select * from Movies where ImdbId=@ImdbID", connect);
                dbmovie.Parameters.Add("ImdbID", SqlDbType.NVarChar).Value = movie.ImdbId;
                movie.ID = (int)dbmovie.ExecuteScalar();

                SqlCommand dbcast = new SqlCommand("Select ID from Casts where ImdbId=@ImdbID", connect);
                dbcast.Parameters.Add("ImdbID", SqlDbType.NVarChar).Value = cast.ImdbId;
                cast.ID = (int)dbcast.ExecuteScalar();

                foreach (Role role in cast.Roles)
                {
                    SqlCommand rolecmd = new SqlCommand("SP_RoleSave", connect);
                    rolecmd.CommandType = CommandType.StoredProcedure;
                    rolecmd.Parameters.Add("@rolename", SqlDbType.NVarChar).Value = role.RoleName;
                    EKS = rolecmd.ExecuteNonQuery();

                    SqlCommand rolid = new SqlCommand("Select ID from Roles where Name=@name", connect);
                    rolid.Parameters.Add("@name", SqlDbType.NVarChar).Value = role.RoleName;
                    role.ID = (int)rolid.ExecuteScalar();

                    SqlCommand mappingcmd = new SqlCommand("SP_MovieCastRoleSave", connect);
                    mappingcmd.CommandType = CommandType.StoredProcedure;
                    mappingcmd.Parameters.Add("@Movie_ID", SqlDbType.Int).Value = movie.ID;
                    mappingcmd.Parameters.Add("@Cast_ID", SqlDbType.Int).Value = cast.ID;
                    mappingcmd.Parameters.Add("Role_ID", SqlDbType.Int).Value = role.ID;
                    EKS = mappingcmd.ExecuteNonQuery();
                    if (EKS < 1)
                    {
                        MessageBox.Show("MovieCastRole Save Error");
                    }
                }
            }
            foreach (string image in movie.Images)
            {
                SqlCommand movieimage = new SqlCommand("SP_MovieImageSave", connect);
                movieimage.CommandType = CommandType.StoredProcedure;
                movieimage.Parameters.Add("@imageurl", SqlDbType.NVarChar).Value = image;
                movieimage.Parameters.Add("@movie_Id", SqlDbType.Int).Value = movie.ID;
                EKS = movieimage.ExecuteNonQuery();
                if (EKS < 1)
                {
                    MessageBox.Show("Error");
                }
            }
            foreach (Category cat in movie.Categories)
            {
                SqlCommand catcntrl = new SqlCommand("Select ID from Category where Type=@category", connect);
                catcntrl.Parameters.Add("@category", SqlDbType.NVarChar).Value = cat.Type;
                cat.ID = (int)catcntrl.ExecuteScalar();
                if (cat.ID == 0)
                {
                    MessageBox.Show("Category Not Found");
                }
                else
                {
                    SqlCommand category = new SqlCommand("Insert into MovieCategory values (@movie_Id,@category_Id)", connect);
                    category.Parameters.Add("@movie_Id", SqlDbType.Int).Value = movie.ID;
                    category.Parameters.Add("@category_Id", SqlDbType.Int).Value = cat.ID;
                    EKS = category.ExecuteNonQuery();
                    if (EKS < 1)
                    {
                        MessageBox.Show("Category Save Error");
                    }
                }

            }

        }
        public List<Movie> MovieSelect(string category)
        {
            List<Movie> lstmovies = new List<Movie>();
            SqlCommand cmd = new SqlCommand("SP_MovieCategory", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@category_name", SqlDbType.NVarChar).Value = category;
            reader = cmd.ExecuteReader();
            Movie movie;
            while (reader.Read())
            {
                movie = new Movie();
                movie.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                movie.Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                movie.Description = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                movie.Raiting = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                movie.ImdbId = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                movie.Poster = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                lstmovies.Add(movie);
            }
            reader.Close();
            return lstmovies;
        }
        public void CategorySave(string category)
        {
            SqlCommand catcntrl = new SqlCommand("Select ID from Category where Type=@category", connect);
            catcntrl.Parameters.Add("@category", SqlDbType.NVarChar).Value = category;
            object id = catcntrl.ExecuteScalar();
            if (id == null)
            {
                SqlCommand catcmd = new SqlCommand("Insert into Category values (@type)", connect);
                catcmd.Parameters.Add("@type", SqlDbType.NVarChar).Value = category;
                EKS = catcmd.ExecuteNonQuery();
                if (EKS < 1)
                {
                    MessageBox.Show("Error");
                }
            }
        }
        public List<Category> CategoryList()
        {
            SqlCommand cmd = new SqlCommand("Select * from Category", connect);
            reader = cmd.ExecuteReader();
            Category cat;
            List<Category> lstcategory = new List<Category>();
            while (reader.Read())
            {
                cat = new Category();
                cat.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                cat.Type = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                lstcategory.Add(cat);
            }
            reader.Close();
            return lstcategory;
        }
        public Cast CastControl(Cast cast)
        {
            SqlCommand castcmd = new SqlCommand("Select * from Casts where ID=@cast_Id", connect);
            castcmd.Parameters.Add("@cast_Id", SqlDbType.Int).Value = cast.ID;
            reader = castcmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    cast.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                    cast.ImdbId = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                    cast.Name = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                    cast.Born = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                    cast.Died = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                    cast.Description = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                    cast.ProfileImage = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
                    cast.OtherPhotos = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                }
                reader.Close();
                SqlCommand cmd = new SqlCommand("Select MovieName from Filmography where Cast_ID=@cast_Id", connect);
                cmd.Parameters.Add("@cast_Id", SqlDbType.Int).Value = cast.ID;
                reader = cmd.ExecuteReader();

                Movie movie;
                while (reader.Read())
                {
                    movie = new Movie();
                    movie.Name = reader.IsDBNull(0) ? string.Empty : reader.GetString(0);
                    cast.Filmographies.Add(movie);
                }
                reader.Close();

                SqlCommand imagescmd = new SqlCommand("Select ImageUrl from CastImage where Cast_ID=@cast_Id", connect);
                imagescmd.Parameters.Add("@cast_Id", SqlDbType.Int).Value = cast.ID;
                reader = imagescmd.ExecuteReader();
                while (reader.Read())
                {
                    cast.Images.Add(reader.IsDBNull(0) ? string.Empty : reader.GetString(0));
                }
                reader.Close();

                SqlCommand knowncmd = new SqlCommand("Select Image from KnownFor where Cast_ID=@cast_Id", connect);
                knowncmd.Parameters.Add("@cast_Id", SqlDbType.Int).Value = cast.ID;
                reader = knowncmd.ExecuteReader();
                while (reader.Read())
                {
                    cast.KnownFor.Add(reader.IsDBNull(0) ? string.Empty : reader.GetString(0));
                }
                reader.Close();
                return cast;
            }
            else
            {
                return cast;
            }
        }
        public void CastUpdate(Cast cast)
        {
            SqlCommand cmd = new SqlCommand("SP_CastUpdate", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = cast.ID;
            cmd.Parameters.Add("@born", SqlDbType.NVarChar).Value = cast.Born == null ? string.Empty : cast.Born;
            cmd.Parameters.Add("@died", SqlDbType.NVarChar).Value = cast.Died == null ? string.Empty : cast.Died;
            cmd.Parameters.Add("@description", SqlDbType.NVarChar).Value = cast.Died == null ? string.Empty : cast.Description;
            cmd.Parameters.Add("@profileImage", SqlDbType.NVarChar).Value = cast.ProfileImage == null ? string.Empty : cast.ProfileImage;
            cmd.Parameters.Add("@otherPhotos", SqlDbType.NVarChar).Value = cast.OtherPhotos == null ? string.Empty : cast.OtherPhotos;
            EKS = cmd.ExecuteNonQuery();
            if (EKS < 1)
            {
                MessageBox.Show("Error");
            }
            foreach (string image in cast.Images)
            {
                SqlCommand castimage = new SqlCommand("SP_CastImageSave", connect);
                castimage.CommandType = CommandType.StoredProcedure;
                castimage.Parameters.Add("@imageurl", SqlDbType.NVarChar).Value = image;
                castimage.Parameters.Add("@cast_Id", SqlDbType.Int).Value = cast.ID;
                EKS = castimage.ExecuteNonQuery();
                if (EKS < 1)
                {
                    MessageBox.Show("Error");
                }
            }
            foreach (string image in cast.KnownFor)
            {
                SqlCommand knownfor = new SqlCommand("SP_KnownForSave", connect);
                knownfor.CommandType = CommandType.StoredProcedure;
                knownfor.Parameters.Add("@imageurl", SqlDbType.NVarChar).Value = image;
                knownfor.Parameters.Add("@cast_Id", SqlDbType.Int).Value = cast.ID;
                EKS = knownfor.ExecuteNonQuery();
                if (EKS < 1)
                {
                    MessageBox.Show("Error");
                }
            }
            foreach (string role in cast.FilmographiesRoles)
            {
                SqlCommand rolecmd = new SqlCommand("SP_RoleSave", connect);
                rolecmd.CommandType = CommandType.StoredProcedure;
                rolecmd.Parameters.Add("@rolename", SqlDbType.NVarChar).Value = role;
                EKS = rolecmd.ExecuteNonQuery();
            }
            for (int i = 0; i < cast.Filmographies.Count; i++)
            {
                SqlCommand filmography = new SqlCommand("SP_FilmographySave", connect);
                filmography.CommandType = CommandType.StoredProcedure;
                filmography.Parameters.Add("@moviename", SqlDbType.NVarChar).Value = cast.Filmographies[i].Name;
                filmography.Parameters.Add("@cast_Id", SqlDbType.Int).Value = cast.ID;
                filmography.Parameters.Add("@rolename", SqlDbType.NVarChar).Value = cast.FilmographiesRoles[i].ToString();

                EKS = filmography.ExecuteNonQuery();
            }
        }
        public int Register(User user)
        {
            SqlCommand cntrl = new SqlCommand("Select ID from Users where Username=@Username or Email=@Email", connect);
            cntrl.Parameters.Add("@Username", SqlDbType.NVarChar).Value = user.Username;
            cntrl.Parameters.Add("@Email", SqlDbType.NVarChar).Value = user.Email;
            object id = cntrl.ExecuteScalar();
            if (id == null)
            {
                SqlCommand cmd = new SqlCommand("SP_UserSave", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = user.Username;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = user.Email;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = user.Password;
                EKS = cmd.ExecuteNonQuery();
                return EKS;
            }
            else
            {
                DialogResult result = MessageBox.Show("Registered user. Would you like to go to login?", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    return 2;
                }
                else if (result == DialogResult.No)
                {
                    return 3;
                }
                else
                {
                    return 4;
                }
            }


        }
        public User Login(User user)
        {
            SqlCommand cmd = new SqlCommand("Select * from Users where Username=@Username and Password=@Password", connect);
            cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = user.Username;
            cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = user.Password;
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    user.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                    user.Username = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                    user.Email = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                    user.Password = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                }
                return user;
            }
            else
            {
                return null;
            }

        }
        public void WatchListSave(User user, int id)
        {
            SqlCommand cmd = new SqlCommand("SP_WatchListSave", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@user_Id", SqlDbType.Int).Value = user.ID;
            cmd.Parameters.Add("@movie_Id", SqlDbType.Int).Value = id;
            EKS = cmd.ExecuteNonQuery();
            if (EKS < 1)
            {
                MessageBox.Show("Film zaten listede");
            }
        }
        public List<string> WatchListRole(int movieid, int roleid)
        {
            List<string> rolename = new List<string>();
            SqlCommand cmd = new SqlCommand("SP_WatchListRole", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@movie_Id", SqlDbType.Int).Value = movieid;
            cmd.Parameters.Add("@role_Id", SqlDbType.Int).Value = roleid;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                rolename.Add(reader.IsDBNull(0) ? string.Empty : reader.GetString(0));
            }
            reader.Close();
            return rolename;
        }
        public List<Movie> WatchListControl(User user)
        {
            List<Movie> lstMovie = new List<Movie>();
            SqlCommand cmd = new SqlCommand("SP_WatchList", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@user_Id", SqlDbType.Int).Value = user.ID;
            reader = cmd.ExecuteReader();
            Movie movie;
            while (reader.Read())
            {
                movie = new Movie();
                movie.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                movie.Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                movie.Description = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                movie.Raiting = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                movie.ImdbId = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                movie.Poster = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                lstMovie.Add(movie);
            }
            reader.Close();
            return lstMovie;
        }
        public Movie WatchListSelect(string moviename)
        {
            SqlCommand cmd = new SqlCommand("Select * from Movies where Name=@moviename", connect);
            cmd.Parameters.Add("@moviename", SqlDbType.NVarChar).Value = moviename;
            reader = cmd.ExecuteReader();
            Movie movie = new Movie();
            while (reader.Read())
            {
                movie.ID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                movie.Name = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                movie.Description = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                movie.Raiting = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                movie.ImdbId = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                movie.Poster = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
            }
            reader.Close();
            return movie;
        }
        public void WatchListDelete(User user, int id)
        {
            SqlCommand cmd = new SqlCommand("SP_WatchListDelete", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@movie_Id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@user_Id", SqlDbType.Int).Value = user.ID;
            EKS = cmd.ExecuteNonQuery();
            if (EKS < 1)
            {
                MessageBox.Show("WatchListDelete Error");
            }
            else
            {
                MessageBox.Show("Movie Deleted");
            }
        }
        public List<string> Filmography(int castid, string rolename)
        {
            List<string> lstfilmography = new List<string>();
            SqlCommand cmd = new SqlCommand("SP_FilmographySelect", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@cast_Id", SqlDbType.Int).Value = castid;
            cmd.Parameters.Add("@role_Name", SqlDbType.NVarChar).Value = rolename;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lstfilmography.Add(reader.IsDBNull(0) ? string.Empty : reader.GetString(0));
            }
            reader.Close();
            return lstfilmography;
        }
    }
}
