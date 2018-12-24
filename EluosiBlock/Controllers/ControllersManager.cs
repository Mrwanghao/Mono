using System.Collections.Generic;




public class ControllersManager
{
    private static Dictionary<string, Controller> m_controllers = new Dictionary<string, Controller>();

    public static void Push(string _name, Controller _controller)
    { 
        if(m_controllers.ContainsKey(_name))
        {
            return;
        }

        _controller.initialize();
        m_controllers.Add(_name, _controller);
    }

    public static void update()
    { 
        if(m_controllers.Count == 0)
        {
            return;
        }

        foreach (Controller controller in m_controllers.Values)
        {
            controller.update();
        }
    }

}

