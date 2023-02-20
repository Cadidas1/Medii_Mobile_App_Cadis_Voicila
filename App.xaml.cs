
using System;
using Medii_Mobile_App_Cadis_Voicila.Data;
using System.IO;

namespace Medii_Mobile_App_Cadis_Voicila;

public partial class App : Application
{
    static InchiriereDatabase database;
    public static InchiriereDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new
               InchiriereDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
               LocalApplicationData), "Inchiriere.db3"));
            }
            return database;
        }
    }
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
