/* Authors: David Cordle, Michael Troller
 * Updated June 26th 2019
 * Version: 4.5
 * Description: Generic
 * Game Object
 */
namespace SuperMario
{
    public interface IGameObject
    {
        int Height
        {
            get;
        }

        int Width
        {
            get;
        }

        int XCoordinate
        {
            get;

        }

        int YCoordinate
        {
            get;
        }
        void Draw();
        void Update();

    }
}
