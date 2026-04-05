Group5Flight – Phase 2
======================

SETUP STEPS (run once after opening in Visual Studio):
1. Open Package Manager Console (Tools > NuGet Package Manager > Package Manager Console)
2. Run: Add-Migration TimeSpanFix
3. Run: Update-Database
   → This creates flights.sqlite with seed data (4 airlines, 6 flights)

BUGS FIXED IN THIS VERSION:
1. _MainLayout.cshtml – missing </li> closing tag after Privacy nav link
2. Flight.cs – DepartureTime/ArrivalTime changed from DateTime to TimeSpan
   so <input type="time"> model binding works correctly for Add/Edit
3. All views and seed data updated to match TimeSpan format
