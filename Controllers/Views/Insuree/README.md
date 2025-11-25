# ASP.NET MVC Entity Framework Insurance Quote

## Overview
This project calculates insurance quotes based on user input and displays them for administrators.

## Quote Rules
- Base: $50/month
- Age ≤ 18: +$100
- Age 19–25: +$50
- Age ≥ 26: +$25
- Car year < 2000: +$25
- Car year > 2015: +$25
- Porsche: +$25
- Porsche 911 Carrera: +$50 total
- Each speeding ticket: +$10
- DUI: +25% of total
- Full coverage: +50% of total

## Views
- **Create**: User enters details (Quote hidden).
- **Admin**: Shows all quotes with user info.

## Submission
Upload project to GitHub and email `.mdf` and `.ldf` files from `App_Data` to instructor.
