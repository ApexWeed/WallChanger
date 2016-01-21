using System;

namespace WallChanger.Layout
{
    public class LayoutRowStub : IDisposable
    {
        private LayoutEngine LayoutEngine;

        public LayoutRowStub(LayoutEngine LayoutEngine)
        {
            this.LayoutEngine = LayoutEngine;
        }

        #region IDisposable Support
        private bool disposedValue; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    LayoutEngine.EndRow();
                }
                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
