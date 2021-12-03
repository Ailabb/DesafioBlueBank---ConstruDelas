-- DROP SCHEMA public;

CREATE SCHEMA public AUTHORIZATION postgres;

-- DROP SEQUENCE public."Herois_Id_seq";

CREATE SEQUENCE public."Herois_Id_seq"
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE public."Movimentos_Id_seq";

CREATE SEQUENCE public."Movimentos_Id_seq"
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;-- public."Clientes" definition

-- Drop table

-- DROP TABLE public."Clientes";

CREATE TABLE public."Clientes" (
	"Id" int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY,
	"Nome" text NULL,
	"Email" text NULL,
	"Telefone" text NULL,
	"NumeroConta" int4 NOT NULL,
	"Saldo" float8 NOT NULL,
	CONSTRAINT "PK_Clientes" PRIMARY KEY ("Id")
);


-- public."__EFMigrationsHistory" definition

-- Drop table

-- DROP TABLE public."__EFMigrationsHistory";

CREATE TABLE public."__EFMigrationsHistory" (
	"MigrationId" varchar(150) NOT NULL,
	"ProductVersion" varchar(32) NOT NULL,
	CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);


-- public."Movimentos" definition

-- Drop table

-- DROP TABLE public."Movimentos";

CREATE TABLE public."Movimentos" (
	"Id" int4 NOT NULL GENERATED BY DEFAULT AS IDENTITY,
	"OrigemId" int4 NOT NULL,
	"DestinoId" int4 NOT NULL,
	"Valor" float8 NOT NULL,
	CONSTRAINT "PK_Movimentos" PRIMARY KEY ("Id"),
	CONSTRAINT "FK_Movimentos_Clientes_DestinoId" FOREIGN KEY ("DestinoId") REFERENCES public."Clientes"("Id") ON DELETE CASCADE,
	CONSTRAINT "FK_Movimentos_Clientes_OrigemId" FOREIGN KEY ("OrigemId") REFERENCES public."Clientes"("Id") ON DELETE CASCADE
);
CREATE INDEX "IX_Movimentos_DestinoId" ON public."Movimentos" USING btree ("DestinoId");
CREATE INDEX "IX_Movimentos_OrigemId" ON public."Movimentos" USING btree ("OrigemId");
