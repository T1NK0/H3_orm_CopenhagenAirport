------------------------------DROP DATABASE
DROP DATABASE IF EXISTS "CopenhagenAirport";

------------------------------CREATE DATABASE½
CREATE DATABASE "CopenhagenAirport";

------------------------------DROP TABLES
DROP TABLE IF EXISTS "Booking" CASCADE;
DROP TABLE IF EXISTS "Airport" CASCADE;
DROP TABLE IF EXISTS "Airline" CASCADE;
DROP TABLE IF EXISTS "Gate" CASCADE;

------------------------------CREATE TABLES
CREATE TABLE "Booking"(
	"booking_id" int, --PK
	"time" timestamp,
	"flight_number" varchar(10),
	"state" bool,
	"airport_id" int, --FK to Airport
	"airline_id" int, --FK to Airline
	"gate_id" int --FK to Gates
);

CREATE TABLE "Airport" (
	"airport_id" int, --PK
	"city" varchar(60),
	"country" varchar(30),
	"airport_name" varchar(60)
);

CREATE TABLE "Airline"(
	"airline_id" int, --PK
	"airline_name" varchar(90)
);

CREATE TABLE "Gate"(
	"gate_id" int, --PK
	"gate_name" varchar(30)
);

------------------------------ALTER TABLES
ALTER TABLE "Airport" 
ALTER COLUMN "airport_id" SET NOT NULL,
ALTER COLUMN "city" SET NOT NULL,
ALTER COLUMN "country" SET NOT NULL,
ALTER COLUMN "airport_name" SET NOT NULL,
ADD CONSTRAINT "PK_airport_id" PRIMARY KEY ("airport_id");

ALTER TABLE "Airline"
ALTER COLUMN "airline_id" SET NOT NULL,
ALTER COLUMN "airline_name" SET NOT NULL,
ADD CONSTRAINT "PK_airline_id" PRIMARY KEY ("airline_id");

ALTER TABLE "Gate"
ALTER COLUMN "gate_id" SET NOT NULL,
ALTER COLUMN "gate_name" SET NOT NULL,
ADD CONSTRAINT "PK_gate_id" PRIMARY KEY ("gate_id");

ALTER TABLE "Booking"
ALTER COLUMN "booking_id" SET NOT NULL,
ALTER COLUMN "time" SET NOT NULL,
ALTER COLUMN "flight_number" SET NOT NULL,
ALTER COLUMN "state" SET NOT NULL,
ALTER COLUMN "airport_id" SET NOT NULL,
ALTER COLUMN "airline_id" SET NOT NULL,
ALTER COLUMN "gate_id" SET NOT NULL,
ADD CONSTRAINT "PK_booking_id" PRIMARY KEY ("booking_id"),
ADD CONSTRAINT "FK_Airport" FOREIGN KEY ("airport_id") REFERENCES "Airport"("airport_id"),
ADD CONSTRAINT "FK_Airline" FOREIGN KEY ("airline_id") REFERENCES "Airline"("airline_id"),
ADD CONSTRAINT "FK_Gate" FOREIGN KEY ("gate_id") REFERENCES "Gate"("gate_id");

--------------------------------------------------------------------------- INSERTS

INSERT INTO "Airport" ("airport_id", "city", "country", "airport_name") 
VALUES 
(1, 'Dusseldorf', 'Germany', 'Dusseldorf International Airport'),
(2, 'Bornholm', 'Denmark', 'Bornholm Airport');

INSERT INTO "Airline" ("airline_id", "airline_name") 
VALUES 
(1, 'SCANDINAVIAN AIRLINES'),
(2, 'DAT');

INSERT INTO "Gate" ("gate_id", "gate_name") 
VALUES 
(1, 'B3A'),
(2, 'A11');

INSERT INTO "Booking" ("booking_id", "time", "flight_number", "state", "airport_id", "airline_id", "gate_id") 
VALUES 
(1, '2022-02-23 07:53:25', 'SK620', false, 1, 1, 1),
(2, '2022-02-23 07:53:25', 'DX033', false, 2, 2, 2);


SELECT
booking_id,
time,
flight_number,
state,
airport_name,
airline_name,
gate_name
FROM "Booking"
INNER JOIN "Airport" on "Booking".airport_id = "Airport".airport_id
INNER JOIN "Airline" on "Booking".airline_id = "Airline".airline_id
INNER JOIN "Gate" on "Gate".gate_id = "Gate".gate_id
WHERE booking_id = 1