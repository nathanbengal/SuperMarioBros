/* Authors: Michael Troller
 * Version: 2.1
 * Description: Controller,
 * Currently only used by keyboard,
 * could be used by gamepad as well though
 */

namespace SuperMario
{
    interface IController
    {
        void Update();
        void ClearKeyBindings();
    }
}
