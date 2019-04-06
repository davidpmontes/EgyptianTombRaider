public interface IHeroMover
{
    void Init(Hero hero);
    void Init(Hero hero, float x);
    void Move();
    void Gravity();
}
