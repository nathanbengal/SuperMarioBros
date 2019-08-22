namespace SuperMario
{
    class BumpBlockCommand : ICommand
    {
        private IBlock block;

        public BumpBlockCommand(IBlock gameObject)
        {
            block = gameObject;
        }


        //Execute as mandated by ICommand interface
        public void Execute()
        {
            block.Bump();
        }
    }
}
