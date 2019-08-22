namespace SuperMario
{
    class LeftMovingItem : IItemState
    {
        public IItemState Left()
        {
            return this;
        }

        public IItemState Right()
        {
            return new RightMovingItem();
        }
    }
}
