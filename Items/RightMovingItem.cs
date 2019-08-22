namespace SuperMario
{
    class RightMovingItem : IItemState
    {
        public IItemState Left()
        {
            return new LeftMovingItem();
        }

        public IItemState Right()
        {
            return this;
        }
    }
}
