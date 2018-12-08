
DROP TABLE IF EXISTS CATEGORIE_RECETTE ;
CREATE TABLE CATEGORIE_RECETTE (CTG_ID_Entite_1 BIGINT IDENTITY NOT NULL,
 CTG_NOM_CATEGORIE_RECETTE VARCHAR(30),
 PRIMARY KEY (CTG_ID_Entite_1)) ;

DROP TABLE IF EXISTS RECETTE ;
CREATE TABLE RECETTE (R_ID_RECETTE BIGINT IDENTITY NOT NULL,
 R_NOM_RECETTE VARCHAR(50),
 R_DESC_RECETTE VARCHAR(800),
 R_TPSPREP_RECETTE TIME(0),
 R_TPSCUISSON_RECETTE TIME(0),
 R_TPSREPOS_RECETTE TIME(0),
 R_INGREDIENTS_RECETTE VARCHAR(200),
 R_ACCOMPAGNEMENT_RECETTE VARCHAR(50),
 PRIMARY KEY (R_ID_RECETTE)) ;

DROP TABLE IF EXISTS PERSONNEL ;
CREATE TABLE PERSONNEL (P_ID_PERSONNEL BIGINT IDENTITY NOT NULL,
 P_NOM_PERSONNEL BIGINT,
 PRIMARY KEY (P_ID_PERSONNEL)) ;

DROP TABLE IF EXISTS MATERIEL ;
CREATE TABLE MATERIEL (M_ID_Materiel BIGINT IDENTITY NOT NULL,
 M_NOM_Materiel VARCHAR(30), M_QTEMAX_Materiel BIGINT,
 PRIMARY KEY (M_ID_Materiel)) ;

DROP TABLE IF EXISTS STOCK ;
CREATE TABLE STOCK (S_ID_STOCK BIGINT IDENTITY NOT NULL,
 S_QTE_STOCK BIGINT,
 PRIMARY KEY (S_ID_STOCK)) ;

DROP TABLE IF EXISTS CATEGORIE_STOCK ;
CREATE TABLE CATEGORIE_STOCK (CTG_STOCK_ID_CATEGORIE_STOCK BIGINT IDENTITY NOT NULL,
 CTG_STOCK_NOM_CATEGORIE_STOCK VARCHAR(30),
 PRIMARY KEY (CTG_STOCK_ID_CATEGORIE_STOCK)) ;

DROP TABLE IF EXISTS TYPE_INGREDIENT ;
 CREATE TABLE TYPE_INGREDIENT (TP_I_ID_TYPE_INGREDIENT BIGINT IDENTITY NOT NULL,
 TP_I_NOM_TYPE_INGREDIENT VARCHAR(20),
 PRIMARY KEY (TP_I_ID_TYPE_INGREDIENT)) ;

DROP TABLE IF EXISTS INGREDIENT ;
CREATE TABLE INGREDIENT (I_ID_INGREDIENT BIGINT IDENTITY NOT NULL,
 I_NOM_INGREDIENT VARCHAR(20),
 PRIMARY KEY (I_ID_INGREDIENT)) ;


ALTER TABLE RECETTE ADD CONSTRAINT FK_RECETTE_CTG_ID_Entite_1 FOREIGN KEY (CTG_ID_Entite_1) REFERENCES CATEGORIE_RECETTE (CTG_ID_Entite_1); ALTER TABLE STOCK ADD CONSTRAINT FK_STOCK_CTG_STOCK_ID_CATEGORIE_STOCK FOREIGN KEY (CTG_STOCK_ID_CATEGORIE_STOCK) REFERENCES CATEGORIE_STOCK (CTG_STOCK_ID_CATEGORIE_STOCK); ALTER TABLE INGREDIENT ADD CONSTRAINT FK_INGREDIENT_TP_I_ID_TYPE_INGREDIENT FOREIGN KEY (TP_I_ID_TYPE_INGREDIENT) REFERENCES TYPE_INGREDIENT (TP_I_ID_TYPE_INGREDIENT);
