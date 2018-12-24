using System.Collections.Generic;

public class UIManager
{
    private static Dictionary<string, Menu> m_menus = new Dictionary<string, Menu>();

    public static void Push(string _name, Menu _menu)
    {
        if (m_menus.ContainsKey(_name))
        {
            return;
        }

        _menu.initialize();
        m_menus.Add(_name, _menu);
    }

    public static void initialize()
    { 
        foreach(Menu menu in m_menus.Values)
        {
            menu.initialize();
        }
    }


    public static void update()
    {
        foreach (Menu menu in m_menus.Values)
        {
            menu.update();
        }
    }

}

