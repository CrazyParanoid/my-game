using NUnit.Framework;

public class HeroTest
{
    [Test]
    public void ShouldHeroHitDamage()
    {
        var hero = TestHeroFactory.NewHero();

        var hit = hero.Damage();

        AssertHit(hit);
    }

    private void AssertHit(Hit hit)
    {
        Assert.AreEqual(hit.IceDamage, TestHeroValues.GENERAL_ICE_HERO_DAMAGE);
        Assert.AreEqual(hit.Physicaldamage, TestHeroValues.GENERAL_PHYSICAL_HERO_DAMAGE);
        Assert.AreEqual(hit.FireDamage, TestHeroValues.GENERAL_FIRE_HERO_DAMAGE);
        Assert.AreEqual(hit.WindDamage, TestHeroValues.GENERAL_WIND_HERO_DAMAGE);
    }

    [Test]
    public void ShouldHeroReceiveDamage()
    {
        var hero = TestHeroFactory.NewHero();

        hero.ReceiveDamage(TestHitFactory.NewSmallHitForHero());

        Assert.AreEqual(hero.CurrentHealth, TestHeroValues.CURRENT_HERO_HEALTH_AFTER_SMALL_HIT);
    }

    [Test]
    public void ShouldGetHeroCurrentHealth()
    {
        var hero = TestHeroFactory.NewHero();

        var currentHealth = hero.CurrentHealth;

        Assert.AreEqual(currentHealth, TestHeroValues.CURRENT_HERO_HEALTH_VALUE);
        Assert.IsFalse(hero.IsDead());
    }

    [Test]
    public void ShouldHeroDie()
    {
        var hero = TestHeroFactory.NewHero();

        hero.ReceiveDamage(TestHitFactory.NewLargeHitForHero());

        Assert.IsTrue(hero.IsDead());
    }

    [Test]
    public void ShouldHeroDontTakeExpirienceIfEnemyNotDead()
    {
        var hero = TestHeroFactory.NewHero();

        hero.TakeExpirience(TestNpcFactory.NewNpc());

        Assert.AreEqual(hero.CurrentLevel, TestHeroValues.FIRST_LEVEL);
        Assert.AreEqual(hero.UpExpirience, TestHeroValues.BASIC_UP_EXPIRIENCE);
        Assert.AreEqual(hero.CurrentExpirience, 0);
    }

    [Test]
    public void ShouldHeroTakeExpirience()
    {
        var hero = TestHeroFactory.NewHero();

        hero.TakeExpirience(TestNpcFactory.NewDeadNpc());

        Assert.AreEqual(hero.CurrentExpirience, TestNpcValues.EXPIRIENCE);
    }

    [Test]
    public void ShouldHeroUpLevel()
    {
        var hero = TestHeroFactory.NewHero();

        hero.TakeExpirience(TestNpcFactory.NewDeadNpcWithLargeExpirience());

        Assert.AreEqual(hero.CurrentLevel, TestHeroValues.SECOND_LEVEL);
        Assert.AreEqual(hero.UpExpirience, TestHeroValues.THIRD_LEVEL_UP_EXPIRIENCE);
        Assert.AreEqual(hero.CurrentExpirience, 0);
    }


    [Test]
    public void ShouldHealHeroByHealthPotion()
    {
        var hero = TestHeroFactory.NewHeroWithReducedHealth();

        hero.TakeHealthPotion(TestItemsFactory.NewHealthPotion());

        Assert.AreEqual(hero.CurrentHealth, TestHeroValues.REPLENISHED_CURRENT_HERO_HEALTH_VALUE);
    }
}
