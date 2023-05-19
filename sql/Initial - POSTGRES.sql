CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "Dependencies" (
    "Id" uuid NOT NULL,
    "Description" VARCHAR(200) NOT NULL,
    "Address" VARCHAR(200) NOT NULL,
    CONSTRAINT "PK_Dependencies" PRIMARY KEY ("Id")
);

CREATE TABLE "Responsibles" (
    "Id" uuid NOT NULL,
    "Name" VARCHAR(200) NOT NULL,
    "Phone" VARCHAR(20) NOT NULL,
    "Email" VARCHAR(100) NOT NULL,
    CONSTRAINT "PK_Responsibles" PRIMARY KEY ("Id")
);

CREATE TABLE "Actives" (
    "Id" uuid NOT NULL,
    "ResponsibleId" uuid NOT NULL,
    "DependencyId" uuid NOT NULL,
    "Name" VARCHAR(200) NOT NULL,
    "Brand" VARCHAR(200) NOT NULL,
    CONSTRAINT "PK_Actives" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Actives_Dependencies_DependencyId" FOREIGN KEY ("DependencyId") REFERENCES "Dependencies" ("Id"),
    CONSTRAINT "FK_Actives_Responsibles_ResponsibleId" FOREIGN KEY ("ResponsibleId") REFERENCES "Responsibles" ("Id")
);

CREATE INDEX "IX_Actives_DependencyId" ON "Actives" ("DependencyId");

CREATE INDEX "IX_Actives_ResponsibleId" ON "Actives" ("ResponsibleId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230519175955_Initial', '7.0.5');

COMMIT;

