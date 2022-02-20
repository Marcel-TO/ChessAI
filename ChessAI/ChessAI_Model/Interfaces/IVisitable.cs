namespace ChessAI_Model.Interfaces
{
    using System;

    public interface IVisitable
    {
        void Accept(IVisitor visitor);
    }
}
