
using System.Collections.Generic;




public class Constructor
{
    private List<Task> m_Tasks = new List<Task>();

    public Constructor()
    { 
        for(int i = 0; i < 10; i++)
        { 
            for(int j = 0; j < 10; j++)
            {
                var task = new Task();
                task.SetPosition(new Microsoft.Xna.Framework.Vector2((float)(i * 20.0f) + 100.0f, (float)(j * 20.0f) + 100.0f));
                m_Tasks.Add(task);
            }
        }
    }

    public void update()
    { 
        foreach(Task element in m_Tasks)
        {
            element.update();
        }
    }


}
