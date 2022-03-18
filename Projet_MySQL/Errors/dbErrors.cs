using System.Windows.Forms;

namespace Projet_MySQL.Errors
{
    public static class dbErrors
    {
        /// <summary>
        /// Show a custom error with a already defined title
        /// </summary>
        /// <param name="error"></param>
        public static void CreateErrorMessage(string error)
        {
            MessageBox.Show(error, "My_SQL Error");
        }

        /// <summary>
        /// Show if the user is not connected
        /// Temporary Method
        /// </summary>
        public static void ShowConnected()
        {
            CreateErrorMessage("Veuillez vous connecter au SGBD !");
        }

        /// <summary>
        /// Show if a field is empty
        /// Temporary Method
        /// </summary>
        public static void ShowEmpty()
        {
            CreateErrorMessage("Veuillez remplir le champ du nom de la base de donnée !");
        }

    }
}
