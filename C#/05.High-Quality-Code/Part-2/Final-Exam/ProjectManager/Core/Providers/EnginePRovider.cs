namespace ProjectManager.Core.Providers
{
    public class EngineProvider
    {
        private Engine engine;

        public EngineProvider(Engine engine)
        {
            this.engine = engine;
        }

        public void StartEngine()
        {
            this.engine.Start();
        }
    }
}
