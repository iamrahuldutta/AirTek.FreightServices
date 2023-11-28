# AirTek.FreightServices

Console based app.

Example input:
*****************************
Day 1:
Flight 1: Montreal airport (YUL) to Toronto (YYZ)
Flight 2: Montreal (YUL) to Calgary (YYC)
Flight 3: Montreal (YUL) to Vancouver (YVR)
Day 2:
Flight 4: Montreal airport (YUL) to Toronto (YYZ)
Flight 5: Montreal (YUL) to Calgary (YYC)
Flight 6: Montreal (YUL) to Vancouver (YVR)
Day 3:
Flight 7: Montreal airport (YUL) to Toronto (YYZ)
Flight 8: Montreal (YUL) to Calgary (YYC)
Flight 9: Montreal (YUL) to Vancouver (YVR)
******************************


Expected output for flights scheduling:
Flight: 1, departure: YUL, arrival: YYZ, day: 1
...
Flight: 6, departure: <departure_city>, arrival: <arrival_city>, day: x


Expected output for Orders and Flight map:
order: order-001, flightNumber: 1, departure: <departure_city>, arrival: <arrival_city>, day: x
...
order: order-099, flightNumber: 1, departure: <departure_city>, arrival: <arrival_city>, day: x
if an order has not yet been scheduled, output:
order: order-X, flightNumber: not scheduled
