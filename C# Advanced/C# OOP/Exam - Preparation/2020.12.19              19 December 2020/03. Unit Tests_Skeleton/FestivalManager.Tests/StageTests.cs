// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class StageTests
    {
        private Song song1;
        private Song song2;
        private Performer performer1;
        private Performer performer2;
        private Stage stage;

        [SetUp]
        public void Setup()
        {
            song1 = new Song("qwe", new TimeSpan(0, 1, 59));
            song2 = new Song("asd", new TimeSpan(0, 3, 59));
            performer1 = new Performer("a", "b", 20);
            performer2 = new Performer("z", "v", 10);
            stage = new Stage();
        }
        [Test]
        public void AddPerformer_ThrowsException_WhenIsNull()
        {
            Performer performer = null;

            Assert.Throws<ArgumentNullException>(() => this.stage.AddPerformer(performer));
        }

        [Test]
        public void AddPerformer_ThrowsException_WhenPerformerAgeIsUnder18()
        {
            Assert.Throws<ArgumentException>(() => this.stage.AddPerformer(performer2));
        }

        [Test]
        public void AddPerformer_AddsPerformer_WhenPerformerIsValid()
        {
            this.stage.AddPerformer(performer1);

            Assert.That(stage.Performers.Contains(performer1));
        }

        [Test]
        public void AddSong_ThrowsException_WhenIsNull()
        {
            Song song = null;

            Assert.Throws<ArgumentNullException>(() => this.stage.AddSong(song));
        }

        [Test]
        public void AddSong_ThrowsException_WhenDurationIsUnderMinute()
        {
            Song song = new Song("a", new TimeSpan(0, 0, 59));

            Assert.Throws<ArgumentException>(() => this.stage.AddSong(song));
        }


        [Test]
        public void AddSongToPerformer_ReturnsCorrect_WhenEverythingIsFine()
        {
            this.stage.AddPerformer(performer1);
            this.stage.AddSong(song1);
            this.stage.AddSong(song2);
            string result = this.stage.AddSongToPerformer(song1.Name, performer1.FullName);

            Assert.That(stage.Performers.Where(x => x.FullName == performer1.FullName).FirstOrDefault().SongList.Contains(song1));
            Assert.That(result, Is.EqualTo($"{song1} will be performed by {performer1}"));
        }

        [Test]
        public void AddSongToPerformer_ThrowsExeption_WhenThereIsNoSuchPerformer()
        {
            string performerName = "aaaaa";
            stage.AddSong(song1);

            Assert.Throws<ArgumentException>(() => this.stage.AddSongToPerformer(song1.Name, performerName));
        }

        [Test]
        public void AddSongToPerformer_ThrowsExeption_WhenThereIsNoSuchSong()
        {
            string SongName = "aaaaa";
            stage.AddPerformer(performer1);

            Assert.Throws<ArgumentException>(() => this.stage.AddSongToPerformer(SongName, performer1.FullName));
        }

        [Test]
        public void Play_ReturnsCorrect_WhenEverythingIsFine()
        {
            this.stage.AddPerformer(performer1);
            this.stage.AddSong(song1);
            this.stage.AddSong(song2);
            this.stage.AddSongToPerformer(song1.Name, performer1.FullName);
            this.stage.AddSongToPerformer(song2.Name, performer1.FullName);

            string result = this.stage.Play();

            
            Assert.That(result, Is.EqualTo($"1 performers played 2 songs"));
        }
    }
}