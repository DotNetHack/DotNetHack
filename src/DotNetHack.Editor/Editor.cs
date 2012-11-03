using DotNetHack.Shared.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetHack.Editor
{
    /// <summary>
    /// Editor
    /// </summary>
    internal static class Editor
    {
        /// <summary>
        /// Editor
        /// </summary>
        static Editor() { }

        /// <summary>
        /// LoadPackage
        /// </summary>
        public static void LoadPackage(string fullPath)
        {
            CurrentPackage = Shared.R.LoadPak(fullPath);
           
            Touched = false;
            LastSavedPackage = fullPath;
            LastPackage = fullPath;

            Shared.R.LoadTileSetImage(CurrentPackage);
        }

        /// <summary>
        /// LoadLastPackage
        /// </summary>
        static void LoadLastPackage()
        {
            LoadPackage(LastPackage);
        }

        /// <summary>
        /// TryLoadLastPackage
        /// </summary>
        public static bool TryLoadLastPackage()
        {
            if (!string.IsNullOrEmpty(LastPackage))
            {
                if (File.Exists(LastPackage))
                {
                    Editor.LoadLastPackage();

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Saves the CurrentPackage as the last filename that was saved.
        /// </summary>
        public static void SaveLastSavedPackage()
        {
            if (!string.IsNullOrEmpty(LastSavedPackage))
            {
                if (File.Exists(LastSavedPackage))
                {
                    SavePackage(LastSavedPackage);
                }
            }
        }

        /// <summary>
        /// SavePackage
        /// </summary>
        /// <param name="fullPath"></param>
        public static void SavePackage(string fullPath)
        {
            Shared.R.SavePak(fullPath, CurrentPackage);
            Touched = false;
            LastPackage = fullPath;
            LastSavedPackage = fullPath;
        }

        /// <summary>
        /// LastSavedPackage
        /// <remarks>The last package that was saved</remarks>
        /// </summary>
        static string LastSavedPackage = string.Empty;

        /// <summary>
        /// Package
        /// </summary>
        public static Package CurrentPackage
        {
            get
            {
                return PackageBackingStore;
            }

            set
            {
                Touched = true;
                PackageBackingStore = value;
            }
        }

        /// <summary>
        /// the backing store for the package,
        /// </summary>
        static Package PackageBackingStore = null;

        /// <summary>
        /// ModifiedCurrentPackage
        /// </summary>
        public static bool Touched { get; private set; }

        /// <summary>
        /// LastPackage
        /// </summary>
        public static string LastPackage
        {
            get { return Properties.Settings.Default.LastPackage; }
            set
            {
                Properties.Settings.Default.LastPackage = value;
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// OpenForm
        /// </summary>
        public static void OpenForm(Form parent, Form newForm)
        {
            newForm.TopLevel = false;
            parent.ParentForm.Controls.Add(newForm);
            newForm.Show(parent.ParentForm);
        }

        /// <summary>
        /// The main form
        /// </summary>
        public static Form MainForm { get; set; }
    }
}
