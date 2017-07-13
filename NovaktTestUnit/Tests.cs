using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using System.Threading;


namespace NovaktTestUnit
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            IApp _app = null;

            switch (TestEnvironment.Platform)
            {
                case TestPlatform.Local:
                    if (platform == Platform.Android)
                        _app = ConfigureApp.Android.StartApp();
                    break;

               // case TestPlatform.TestCloudAndroid:
               //     _app = ConfigureApp.Android.StartApp();
               //     break;
            }
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {
            app = AppInitializer.StartApp(platform);
            TestConnexion();

            app = AppInitializer.StartApp(platform);
            TestProduits();

            app = AppInitializer.StartApp(platform);
            TestChantiers();

            app = AppInitializer.StartApp(platform);
            TestClients();
        }

        public void TestProduits()
        {
            TestConnexion();
            TestSynchro();

            app.WaitForElement(c => c.Marked("Produits"));
            app.Tap("Produits");

            app.WaitForElement(c => c.Marked("ListeCategorieProduit"));
            app.Tap("ListeCategorieProduit");

            app.WaitForElement(c => c.Marked("ListeProduit"));
            app.Tap("ListeProduit");
        }

        public void TestChantiers()
        {
            TestConnexion();
            TestSynchro();

            app.WaitForElement(c => c.Marked("Chantiers"));
            app.Tap("Chantiers");

            app.WaitForElement(c => c.Marked("ListeChantier"));
            app.Tap("ListeChantier");
        }

        public void TestClients()
        {
            TestConnexion();
            TestSynchro();

            app.WaitForElement(c => c.Marked("Clients"));
            app.Tap("Clients");

            app.WaitForElement(c => c.Marked("ListeClient"));
            app.Tap("ListeClient");
        }

        // TODO
        public void TestAjoutClient()
        {
            TestConnexion();
            TestSynchro();

            app.WaitForElement(c => c.Marked("Clients"));
            app.Tap("Clients");
        }

        // TODO
        public void TestAjoutEstimation()
        {
            TestConnexion();
            TestSynchro();

            app.WaitForElement(c => c.Marked("Clients"));
            app.Tap("Clients");
        }

        // TODO
        public void TestConsulterEstimation()
        {
            TestConnexion();
            TestSynchro();

            app.WaitForElement(c => c.Marked("Clients"));
            app.Tap("Clients");
        }

        public void TestSynchro()
        {
            app.WaitForElement(c => c.Marked("Synchro"));
            app.Tap("Synchro");
        }

        public void TestConnexion()
        {
            app.WaitForElement(c => c.Marked("EntryLogin"));
            app.EnterText(x => x.Marked("EntryLogin"), "toto");
            app.DismissKeyboard();
            app.WaitForElement(c => c.Marked("EntryPassword"));
            app.EnterText(y => y.Marked("EntryPassword"), "tata");
            app.DismissKeyboard();
            app.WaitForElement(c => c.Marked("ButtonLogin"));
            app.Tap("ButtonLogin");           
        }
    }
}

