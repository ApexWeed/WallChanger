using System;

namespace WallChanger.Layout
{
    public struct LayoutEndStub : IDisposable
    {
        public enum StubType
        {
            Row,
            GroupBox
        }

        private LayoutEngine LayoutEngine;
        private StubType EndStubType;

        public LayoutEndStub(LayoutEngine LayoutEngine, StubType StubType)
        {
            this.LayoutEngine = LayoutEngine;
            this.EndStubType = StubType;
        }

        public void Dispose()
        {
            switch (EndStubType)
            {
                case StubType.Row:
                    {
                        LayoutEngine.EndRow();
                        break;
                    }
                case StubType.GroupBox:
                    {
                        LayoutEngine.EndGroupBox();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

        }
    }
}
