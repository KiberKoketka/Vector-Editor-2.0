namespace WinFormGamVector2D
{
    public enum StateFlag
    {
        DrawLine1,
        DrawLine2,
        DrawEllipse1,
        DrawEllipse2,
        DrawEllipse3,
        DrawRectangle1,
        DrawRectangle2,
        DrawRectangle3
    }
    public class State
    {
        private StateFlag flag;
        public StateFlag Flag
        {
            get { return flag; }
            set
            {
                switch (flag)
                {
                    case StateFlag.DrawLine1:
                        if (value == StateFlag.DrawLine2)
                            flag = value;
                        if (value == StateFlag.DrawLine1 ||
                            value == StateFlag.DrawEllipse1 ||
                            value == StateFlag.DrawRectangle1)
                            flag = value;
                        break;
                    case StateFlag.DrawLine2:
                        if (value == StateFlag.DrawLine1 ||
                            value == StateFlag.DrawEllipse1 ||
                            value == StateFlag.DrawRectangle1)
                            flag = value;
                        break;
                    case StateFlag.DrawEllipse1:
                        if (value == StateFlag.DrawEllipse2)
                            flag = value;
                        if (value == StateFlag.DrawLine1 ||
                            value == StateFlag.DrawEllipse1 ||
                            value == StateFlag.DrawRectangle1)
                            flag = value;
                        break;
                    case StateFlag.DrawEllipse2:
                        if (value == StateFlag.DrawEllipse3)
                            flag = value;
                        break;
                    case StateFlag.DrawEllipse3:
                        if (value == StateFlag.DrawLine1 ||
                            value == StateFlag.DrawEllipse1 ||
                            value == StateFlag.DrawRectangle1)
                            flag = value;
                        break;
                    case StateFlag.DrawRectangle1:
                        if (value == StateFlag.DrawRectangle2)
                            flag = value;
                        if (value == StateFlag.DrawLine1 ||
                            value == StateFlag.DrawEllipse1 ||
                            value == StateFlag.DrawRectangle1)
                            flag = value;
                        break;
                    case StateFlag.DrawRectangle2:
                        if (value == StateFlag.DrawRectangle3)
                            flag = value;
                        break;
                    case StateFlag.DrawRectangle3:
                        if (value == StateFlag.DrawLine1 ||
                            value == StateFlag.DrawEllipse1 ||
                            value == StateFlag.DrawRectangle1)
                            flag = value;
                        break;
                }
            }
        }

    }
}
