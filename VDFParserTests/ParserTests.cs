using NUnit.Framework;
using VDFParser.Models;
using System;

namespace VDFParserTests {
    [TestFixture]
    public class ParserTests {

        [Test]
        public void TestParserBehaviour() {
            var subjects = new string[] { "shortcuts", "shortcuts4" };
            foreach(var subject in subjects) {
                VDFParser.VDFParser.Parse(Helpers.GetResourceNamed(string.Format("{0}.vdf", subject)));
            }

            Assert.Throws<VDFParser.VDFTooShortException>(() => VDFParser.VDFParser.Parse(Helpers.GetResourceNamed("shortcuts2.vdf")));
        }

        [Test]
        public void TestParsedContents() {
            var expectations = new VDFEntry[] {
                new VDFEntry() {
                    appid = 875770417,
                    AppName = "Guitar Hero World Tour",
                    Exe = "\"D:\\Program Files\\GH\\GHWT.exe\"",
                    StartDir = "\"D:\\Program Files\\GH\\\"",
                    Icon = "",
                    ShortcutPath = "",
                    LaunchOptions = "",
                    IsHidden = 0,
                    AllowDesktopConfig = 1,
                    AllowOverlay = 1,
                    OpenVR = 0,
                    Devkit = 0,
                    DevkitGameID = "",
                    LastPlayTime = 1590640610,
                    Tags = new string[] { "Music" },
                    Index = 0
                }
            };
            var entries = VDFParser.VDFParser.Parse(Helpers.GetResourceNamed("shortcuts.vdf"));
            for(var i = 0; i < expectations.Length; i++) {
                var exp = expectations[i];
                var par = entries[i];

                Assert.That(exp.Index, Is.EqualTo(par.Index));
                Assert.That(exp.appid, Is.EqualTo(par.appid));
                Assert.That(exp.AppName, Is.EqualTo(par.AppName));
                Assert.That(exp.Exe, Is.EqualTo(par.Exe));
                Assert.That(exp.StartDir, Is.EqualTo(par.StartDir));
                Assert.That(exp.Icon, Is.EqualTo(par.Icon));
                Assert.That(exp.ShortcutPath, Is.EqualTo(par.ShortcutPath));
                Assert.That(exp.LaunchOptions, Is.EqualTo(par.LaunchOptions));
                Assert.That(exp.IsHidden, Is.EqualTo(par.IsHidden));
                Assert.That(exp.AllowDesktopConfig, Is.EqualTo(par.AllowDesktopConfig));
                Assert.That(exp.AllowOverlay, Is.EqualTo(par.AllowOverlay));
                Assert.That(exp.OpenVR, Is.EqualTo(par.OpenVR));
                Assert.That(exp.Devkit, Is.EqualTo(par.Devkit));
                Assert.That(exp.DevkitGameID, Is.EqualTo(par.DevkitGameID));
                Assert.That(exp.LastPlayTime, Is.EqualTo(par.LastPlayTime));
                Assert.That(exp.Tags, Is.EqualTo(par.Tags));
            }
        }
    }
}
