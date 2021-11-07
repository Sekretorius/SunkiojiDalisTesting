namespace SignalRWebPack {
  public class Director
    {
        private IBuilder _builder;
        
        public IBuilder Builder
        {
            set { _builder = value; } 
        }
        
        // The Director can construct several product variations using the same
        // building steps.
        
        public void BuildArea()
        {
            this._builder.AddNPCs();
            this._builder.AddItems();
            this._builder.AddObstacles();
        }
    }
}