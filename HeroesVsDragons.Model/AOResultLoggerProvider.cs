namespace HeroesVsDragons.Model
{
    /// <summary>
    /// AOR esult logger provider.
    /// </summary>
    public static class AOResultLoggerProvider
    {
        private static IAOResultLogger _aoResultLogger;

        /// <summary>
        /// Sets the AOR esult logger.
        /// </summary>
        /// <param name="aoResultLogger">Ao result logger.</param>
        public static void SetAOResultLogger(IAOResultLogger aoResultLogger)
        {
            _aoResultLogger = aoResultLogger;
        }

        /// <summary>
        /// Gets the AOR esult logger.
        /// </summary>
        /// <returns>The AOR esult logger.</returns>
        public static IAOResultLogger GetAOResultLogger()
        {
            return _aoResultLogger;
        }
    }
}
