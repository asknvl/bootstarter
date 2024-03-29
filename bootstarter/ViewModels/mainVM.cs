using bootstarter.Models.paths;
using bootstarter.Models.remote;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Reactive;
using System.Text;

namespace bootstarter.ViewModels
{
    public class mainVM : ViewModelBase
    {
        #region vars
        Paths paths = Paths.getInstance();
        IRemoteManager remoteManager;
        #endregion

        #region properties
        string appname;
        public string AppName
        {
            get => appname;
            set => this.RaiseAndSetIfChanged(ref appname, value);   
        }

        string appversion;
        public string AppVersion
        {
            get => appversion;
            set => this.RaiseAndSetIfChanged(ref appversion, value);
        }

        string status;
        public string Status
        {
            get => status;
            set => this.RaiseAndSetIfChanged(ref status, value);   
        }

        bool isprogress;
        public bool IsProgress
        {
            get => isprogress;
            set => this.RaiseAndSetIfChanged(ref isprogress, value);
        }
        #endregion

        #region commands
        ReactiveCommand<Unit, Unit> updateCmd { get; }
        #endregion        

        public mainVM()
        {

            AppName = "Parser";
            AppVersion = "1.1";
            Status = "������";
            IsProgress = false;

            #region dependencies     
            remoteManager = new RemoteManager(paths.VerURL);
            #endregion

            #region commands
            updateCmd = ReactiveCommand.Create(() => {

                //string user_path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                //string app_path = Path.Combine(user_path, $"Library", $"Application Support", $"XTime");
                //if (!Directory.Exists(app_path))
                //    Directory.CreateDirectory(app_path);
                //WebClient client = new WebClient();
                //string zip_paht = Path.Combine(app_path, "tmp.zip");
                //client.DownloadFile("https://asemenets.com/test.zip", zip_paht);

                //using (var archive = ZipFile.Open(zip_paht, ZipArchiveMode.Update))
                //{
                //    archive.ExtractToDirectory(app_path);
                //}

                //File.Delete(zip_paht);




            });
            #endregion
        }
        public async void OnStarted()
        {
            string remoteVersion = await remoteManager.GetVersion();
        }
    }
}
