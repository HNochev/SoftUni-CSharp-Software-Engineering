using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private int health = 5;
    private int experience = 6;
    private Dummy dummy;
    private Dummy deadDummy;

    [SetUp]
    public void SetUp()
    {
        dummy = new Dummy(health, experience);
        deadDummy = new Dummy(-1, experience);
    }

    [Test]
    public void When_HealthPrivided_ShoudBeSetCorrectly()
    {
        Assert.AreEqual(health, dummy.Health);
    }

    [Test]
    public void When_Attacked_ShouldDecreaseHealth()
    {
        int attackPoints = 3;
        dummy.TakeAttack(attackPoints);

        Assert.That(dummy.Health, Is.EqualTo(health - attackPoints));
    }
    [Test]
    public void When_AttackDummyIsDead_ShouldThrow()
    {
        Assert.That(() => { deadDummy.TakeAttack(5); },
            Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
    }

    [Test]
    public void When_HealthIsPositive_ShouldBeAlive()
    {
        Assert.That(dummy.IsDead(), Is.EqualTo(false));
    }

    [Test]
    public void When_HealthIsZero_ShouldBeDead()
    {
        dummy = new Dummy(0, experience);

        Assert.That(dummy.IsDead(), Is.EqualTo(true));
    }

    [Test]
    public void When_HealthIsNegative_ShouldBeDead()
    {
        Assert.That(deadDummy.IsDead(), Is.EqualTo(true));
    }

    [Test]
    public void When_Dead_ShouldGiveExpirience()
    {
        Assert.That(deadDummy.GiveExperience(), Is.EqualTo(experience));
    }

    [Test]
    public void When_AliveGiveExpirience_ShouldThrow()
    {
        Assert.That(() => { dummy.GiveExperience(); },
            Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
    }
}
