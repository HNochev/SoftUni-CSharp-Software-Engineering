using _02.MicrosoftDepencyInjection.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _02.MicrosoftDepencyInjection
{
    class GameMovement : IGameMovement
    {
        private ILogger logger;
        public GameMovement(ILogger logger)
        {
            this.logger = logger;
        }

        public void Move()
        {
            logger.Log("Game moved!!!");
        }
    }
}
