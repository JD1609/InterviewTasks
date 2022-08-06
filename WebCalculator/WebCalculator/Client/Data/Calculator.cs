namespace WebCalculator.Client.Data
{
    public static class Calculator
    {
        public static List<Button> Numbers
        {
            get
            {
                var list = new List<Button>();

                for (int i = 1; i < 10; i++)
                {
                    list.Add(new Button
                    {
                        Value = i.ToString()
                    });
                }

                list.Add(new Button { Value = "0" });
                list.Add(new Button { Value = "." });
                list.Add(new Button { Value = "C", Background = "aqua" });

                return list;
            }
        }

        public static List<Button> Operations
        {
            get
            {
                var operations = new List<string>() { "+", "-", "*", "/" };
                var operationsButtons = new List<Button>();

                var defaultForeground = "white";
                var defaultBackground = "cornflowerblue";


                foreach (var operation in operations)
                {
                    operationsButtons.Add(new Button
                    {
                        Value = operation,
                        Foreground = defaultForeground, 
                        Background = defaultBackground
                    });
                }


                return operationsButtons;
            }
        }
    }
}
