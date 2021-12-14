using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    private int attack = 5;
    private int durability = 6;
    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void SetUp()
    {
        axe = new Axe(attack, durability);
        dummy = new Dummy(2, 2);
    }

    [Test]
    public void When_AxeAttackAndDurabilityProvided_ShouldBeSetCorrectly()
    {
        Assert.AreEqual(axe.AttackPoints, attack);
        Assert.AreEqual(axe.DurabilityPoints, durability);
    }

    [Test]
    public void When_AxeAttacks_ShoudLoseDurability()
    {
        axe.Attack(dummy);

        Assert.AreEqual(axe.DurabilityPoints, durability - 1);
    }

    [Test]
    public void When_AttackWithZeroDurability_ShouldThrowException()
    {
        axe = new Axe(attack, 0);

        Assert.That(() => { axe.Attack(dummy); },
            Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));

    }

}