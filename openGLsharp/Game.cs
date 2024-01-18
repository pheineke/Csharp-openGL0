using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace openGLsharp
{
    internal class Game : GameWindow
    {
        
        float[] vertices = {
            -0.5f, -0.5f, 0.0f, //Bottom-left vertex
            0.5f, -0.5f, 0.0f, //Bottom-right vertex
            0.0f,  0.5f, 0.0f  //Top vertex
        };
        
        int VertexBufferObject;

        private Shader shader;
        
        
        public Game(int width, int height, string title) : base(GameWindowSettings.Default, new NativeWindowSettings() { Size = (width, height), Title = title }) { }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);

            //Code goes here.

            SwapBuffers();
            
            if (KeyboardState.IsKeyDown(Keys.Escape))
            {
                Close();
            }
        }
        
        protected override void OnLoad()
        {
            base.OnLoad();
            shader = new Shader("shader.vert", "shader.frag");
            
            
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.DeleteBuffer(VertexBufferObject);
            
            //Code goes here
        }
        
        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, e.Width, e.Height);
        }

        protected override void OnUnload()
        {
            shader.Dispose();
        }
        
        
        static void Main()
        {
            Game game = new Game(800, 600, "LearnOpenTK");
            game.Run();
        }
        
    }
}
