﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lms.Application.Commands.Transactions
{
    public record DeleteTransactionCommand: IRequest<Unit>
    {
        public DeleteTransactionCommand(int tid)
        {
            TransactionId = tid;
        }
        public int TransactionId { get; set; }
    }
}