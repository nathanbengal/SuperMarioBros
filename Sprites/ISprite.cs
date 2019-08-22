/* Authors: Michael Troller
 * Version: 2.1
 * Description: Sprite interface. Sprites
 * are for the majority part interchangeable.
 */
namespace SuperMario
{
    public interface ISprite
    {
        int MaxHeight
        {
            get;
        }
        int MaxWidth
        {
            get;
        }
        void Draw(int x, int y);
        void Update();  
    }
}
