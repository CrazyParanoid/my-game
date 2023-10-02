using NUnit.Framework;

public class NpcTest
{

    [Test]
    public void ShouldAttackNpc()
    {
        var npc = TestNpcFactory.NewNpc();

        npc.ReceiveDamage(TestHitFactory.NewSmallHitForHero());

        Assert.IsTrue(npc.IsAattacked());
    }

    [Test]
    public void ShouldNpcDie()
    {
        var npc = TestNpcFactory.NewNpc();

        npc.ReceiveDamage(TestHitFactory.NewLargeHitForHero());

        Assert.IsFalse(npc.IsAattacked());
    }

    [Test]
    public void ShouldSetAttackedToFalseIfEnemyDead()
    {
        var npc = TestNpcFactory.NewNpc();

        npc.SetAttackedToFalseIfEnemyDead(TestNpcFactory.NewDeadNpc());

        Assert.IsFalse(npc.IsAattacked());
    }

    [Test]
    public void ShouldDontSetAttackedToFalseIfEnemyNotDead()
    {
        var npc = TestNpcFactory.NewAttakedNpc();

        npc.SetAttackedToFalseIfEnemyDead(TestNpcFactory.NewNpc());

        Assert.IsTrue(npc.IsAattacked());
    }
}
