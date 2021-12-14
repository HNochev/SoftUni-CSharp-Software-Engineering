using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    private string name = "John";
    private Axe weapon;
    private Hero hero;
    private Dummy dummy;

    [SetUp]
    public void SetUp()
    {
        this.weapon = new Axe(6, 20);
        this.hero = new Hero(name);
        this.dummy = new Dummy(1, 5);
    }

    [Test]
    public void When_AttackedDummyIsDead_ShoudGetExpirience()
    {
        int experienceBeforeAttack = hero.Experience;
        hero.Attack(dummy);
        

        Assert.That(hero.Experience, Is.EqualTo(experienceBeforeAttack + dummy.GiveExperience()));
    }
}