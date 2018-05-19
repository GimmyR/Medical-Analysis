/* TABLES */

CREATE TABLE Axe(
	id VARCHAR(4) PRIMARY KEY, /* AX01 */
	name VARCHAR(255),
	lowerX FLOAT,
	upperX FLOAT,
	lowerNormal FLOAT,
	upperNormal FLOAT,
	marginSimilar FLOAT,
	unit VARCHAR(20)
);

CREATE TABLE Consultation(
	id VARCHAR(4) PRIMARY KEY, /* AX01 */
	name VARCHAR(255),
	lowerX FLOAT,
	upperX FLOAT,
	lowerNormal FLOAT,
	upperNormal FLOAT,
	marginSimilar FLOAT,
	unit VARCHAR(20)
);

CREATE TABLE Disease(
	id VARCHAR(8) PRIMARY KEY, /* DI000001 */
	name VARCHAR(255),
	gender INTEGER,
	lowerAge INTEGER,
	upperAge INTEGER,
	probaOrder INTEGER
);

CREATE TABLE DiseaseDetail(
	disease VARCHAR(8),
	axe VARCHAR(4),
	consultation VARCHAR(4),
	code INTEGER,
	FOREIGN KEY (disease) REFERENCES Disease(id),
	FOREIGN KEY (axe) REFERENCES axe(id),
	FOREIGN KEY (consultation) REFERENCES Consultation(id)
);

CREATE TABLE Patient(
	id VARCHAR(5) PRIMARY KEY NOT NULL, /* PA001 */
	dateDiag DATETIME,
	nom VARCHAR(100),
	sexe INTEGER,
	age INTEGER
);

CREATE TABLE Config(
	patient VARCHAR(5) NOT NULL,
	axe VARCHAR(4) NULL,
	consultation VARCHAR(4),
	valeur FLOAT,
	FOREIGN KEY (patient) REFERENCES Patient(id),
	FOREIGN KEY (axe) REFERENCES Axe(id),
	FOREIGN KEY (consultation) REFERENCES Consultation(id)
);

CREATE TABLE Sequence(
	nom VARCHAR(255) PRIMARY KEY NOT NULL,
	prefixe VARCHAR(5),
	longueur INTEGER,
	valeur INTEGER
);

/* INSERT AXE */

INSERT INTO Axe VALUES('AX01', 'Cholesterol', 					  0, 5, 	 0.35, 2, 0.25, 'g / L');
INSERT INTO Axe VALUES('AX02', 'Glycemie', 						  0, 3, 	 0.7, 1.1, 0.096, 'g / L');
INSERT INTO Axe VALUES('AX03', 'Vitesse de sedimentation', 			  3, 10, 	 3, 8, 0.46, 'mm / H');
INSERT INTO Axe VALUES('AX04', 'Uricemie', 						  0, 100, 	 25, 60, 3.42, 'mg / L');
INSERT INTO Axe VALUES('AX05', 'Triglyceride', 					  0, 3, 	 0, 1.6, 0.1, 'g / L');
INSERT INTO Axe VALUES('AX06', 'Creatinine', 					  0, 13, 	 6, 11, 0.55, 'mg / L');
INSERT INTO Axe VALUES('AX07', 'Taux d''hemoglobine', 			  0, 5.3, 	 4, 5.3, 0.25, 'M / mL');
INSERT INTO Axe VALUES('AX08', 'Globules blancs', 				  0, 12000,  4000, 10000, 500, 'par mm3');
INSERT INTO Axe VALUES('AX09', 'Plaquette', 					  0, 500000, 150000, 400000, 10000, 'par mm3');
INSERT INTO Axe VALUES('AX10', 'Polynucleaire eosinophile', 	  0, 500, 	 40, 400, 20, 'par mm3');
INSERT INTO Axe VALUES('AX11', 'Polynucleaire neutrophile', 	  0, 10000,  2000, 8000, 200, 'par mm3');
INSERT INTO Axe VALUES('AX12', 'Lymphocyte', 					  0, 5000, 	 1000, 4000, 100, 'par mm3');
INSERT INTO Axe VALUES('AX13', 'Antigene prostatique specifique', 0, 5, 	 0, 2.5, 0.25, 'micro-g / L');
INSERT INTO Axe VALUES('AX14', 'Thyreostimuline', 				  0, 2, 	 0.1, 0.5, 0.065, 'mU / L');

/* INSERT CONSULTATION */

INSERT INTO Consultation VALUES('CS01', 'Temperature', 32, 42, 36.5, 37.5, 2, 'Degre');
INSERT INTO Consultation VALUES('CS02', 'Tension', 0, 19, 11, 14, 0.1, 'mmHg');

/* INSERT DISEASE */

INSERT INTO Disease VALUES('DI000001', 'Risque cardio-vasculaire', -1, 0, 100, 1);
INSERT INTO Disease VALUES('DI000002', 'Trouble hormonale', -1, 0, 100, 1);
INSERT INTO Disease VALUES('DI000003', 'Malnutrition', -1, 0, 100, 2);
INSERT INTO Disease VALUES('DI000004', 'Hyperglycemie', -1, 0, 100, 1);
INSERT INTO Disease VALUES('DI000005', 'Diabete', -1, 50, 100, 1);
INSERT INTO Disease VALUES('DI000006', 'Hypoglycemie', -1, 0, 100, 1);
INSERT INTO Disease VALUES('DI000007', 'Grossesse', 0, 16, 50, 1);
INSERT INTO Disease VALUES('DI000008', 'Infection bacterienne', -1, 0, 100, 1);
INSERT INTO Disease VALUES('DI000009', 'Syndrome inflammatoire', -1, 0, 100, 1);
INSERT INTO Disease VALUES('DI000010', 'Goutte', -1, 40, 100, 1);
INSERT INTO Disease VALUES('DI000011', 'Calculs renaux', -1, 0, 100, 2);
INSERT INTO Disease VALUES('DI000012', 'Insuffisance renale', -1, 0, 100, 1);
INSERT INTO Disease VALUES('DI000013', 'Myopathie avec atrophie musculaire', -1, 0, 100, 1);
INSERT INTO Disease VALUES('DI000014', 'Anemie', -1, 0, 100, 1);
INSERT INTO Disease VALUES('DI000015', 'Alteration des defenses immunitaires', -1, 0, 100, 1);
INSERT INTO Disease VALUES('DI000016', 'Thrombose', -1, 0, 100, 1);
INSERT INTO Disease VALUES('DI000017', 'Probleme de coagulation', -1, 0, 100, 1);
INSERT INTO Disease VALUES('DI000018', 'Infection parasitaire', -1, 0, 100, 1);
INSERT INTO Disease VALUES('DI000019', 'Allergie', -1, 0, 100, 2);
INSERT INTO Disease VALUES('DI000020', 'Infection virale', -1, 0, 100, 1);
INSERT INTO Disease VALUES('DI000021', 'Prostatite aigue', -1, 0, 100, 1);
INSERT INTO Disease VALUES('DI000022', 'Adenome prostatique', -1, 0, 100, 2);
INSERT INTO Disease VALUES('DI000023', 'Cancer de la prostate', -1, 0, 100, 3);
INSERT INTO Disease VALUES('DI000024', 'Hypothyroidie', -1, 0, 100, 1);
INSERT INTO Disease VALUES('DI000025', 'Tumeur de l''hypophyse', -1, 0, 100, 1);
INSERT INTO Disease VALUES('DI000026', 'Hyperthyroidie', -1, 0, 100, 2);
INSERT INTO Disease VALUES('DI000027', 'Syndrome nephrotique', -1, 20, 100, 1);
INSERT INTO Disease VALUES('DI000028', 'Anemie aplasique', -1, 0, 100, 1);
INSERT INTO Disease VALUES('DI000029', 'Probleme de reins', -1, 0, 100, 1);

/* INSERT DISEASE DETAIL */

INSERT INTO DiseaseDetail VALUES('DI000001', 'AX01', NULL, 2);
INSERT INTO DiseaseDetail VALUES('DI000001', 'AX05', NULL, 2);
INSERT INTO DiseaseDetail VALUES('DI000002', 'AX01', NULL, 1);
INSERT INTO DiseaseDetail VALUES('DI000003', 'AX01', NULL, 1);
INSERT INTO DiseaseDetail VALUES('DI000004', 'AX02', NULL, 2);
INSERT INTO DiseaseDetail VALUES('DI000005', 'AX02', NULL, 2);
INSERT INTO DiseaseDetail VALUES('DI000005', 'AX05', NULL, 2);
INSERT INTO DiseaseDetail VALUES('DI000006', 'AX02', NULL, 1);
INSERT INTO DiseaseDetail VALUES('DI000007', 'AX03', NULL, 2);
INSERT INTO DiseaseDetail VALUES('DI000007', 'AX04', NULL, 1);
INSERT INTO DiseaseDetail VALUES('DI000007', 'AX08', NULL, 2);
INSERT INTO DiseaseDetail VALUES('DI000008', 'AX03', NULL, 2);
INSERT INTO DiseaseDetail VALUES('DI000008', 'AX08', NULL, 2);
INSERT INTO DiseaseDetail VALUES('DI000008', 'AX11', NULL, 2);
INSERT INTO DiseaseDetail VALUES('DI000009', 'AX03', NULL, 2);
INSERT INTO DiseaseDetail VALUES('DI000009', 'AX08', NULL, 2);
INSERT INTO DiseaseDetail VALUES('DI000010', 'AX04', NULL, 2);
INSERT INTO DiseaseDetail VALUES('DI000011', 'AX04', NULL, 2);
INSERT INTO DiseaseDetail VALUES('DI000012', 'AX06', NULL, 2);
INSERT INTO DiseaseDetail VALUES('DI000013', 'AX06', NULL, 1);
INSERT INTO DiseaseDetail VALUES('DI000014', 'AX07', NULL, 1);
INSERT INTO DiseaseDetail VALUES('DI000015', 'AX08', NULL, 1);
INSERT INTO DiseaseDetail VALUES('DI000016', 'AX09', NULL, 2);
INSERT INTO DiseaseDetail VALUES('DI000017', 'AX09', NULL, 1);
INSERT INTO DiseaseDetail VALUES('DI000018', 'AX10', NULL, 2);
INSERT INTO DiseaseDetail VALUES('DI000019', 'AX10', NULL, 2);
INSERT INTO DiseaseDetail VALUES('DI000020', 'AX12', NULL, 2);
INSERT INTO DiseaseDetail VALUES('DI000021', 'AX13', NULL, 2);
INSERT INTO DiseaseDetail VALUES('DI000022', 'AX13', NULL, 2);
INSERT INTO DiseaseDetail VALUES('DI000023', 'AX13', NULL, 2);
INSERT INTO DiseaseDetail VALUES('DI000024', 'AX14', NULL, 2);
INSERT INTO DiseaseDetail VALUES('DI000025', 'AX14', NULL, 1);
INSERT INTO DiseaseDetail VALUES('DI000026', 'AX14', NULL, 1);
INSERT INTO DiseaseDetail VALUES('DI000027', 'AX04', NULL, 2);
INSERT INTO DiseaseDetail VALUES('DI000027', 'AX06', NULL, 2);
INSERT INTO DiseaseDetail VALUES('DI000028', 'AX09', NULL, 2);
INSERT INTO DiseaseDetail VALUES('DI000028', 'AX08', NULL, 2);
INSERT INTO DiseaseDetail VALUES('DI000029', 'AX08', NULL, 2);
INSERT INTO DiseaseDetail VALUES('DI000029', 'AX06', NULL, 2);
INSERT INTO DiseaseDetail VALUES('DI000029', NULL, 'CS01', 2);
INSERT INTO DiseaseDetail VALUES('DI000029', NULL, 'CS02', 2);

INSERT INTO Sequence VALUES('patient', 'PA', 3, 1);
INSERT INTO Sequence VALUES('consultation', 'CS', 2, 1);

/* TEST QUERY */

SELECT dd.disease , convert(decimal(4, 2), (convert(decimal, COUNT(*)) / convert(decimal, (
	SELECT COUNT(*) FROM DiseaseDetail WHERE disease=dd.disease)
))) * 100 as percentage
FROM DiseaseDetail dd WHERE dd.axe='AX01' AND dd.code=1 GROUP BY dd.disease;

SELECT d.name, ddResult.percentage FROM Disease d, (
	SELECT dd.disease , convert(decimal(4, 2), (convert(decimal, COUNT(*)) / convert(decimal, (
		SELECT COUNT(*) FROM DiseaseDetail WHERE disease=dd.disease)
	))) * 100 as percentage
	FROM DiseaseDetail dd WHERE (dd.axe='AX01' AND dd.code=2) OR (dd.axe='AX05' AND dd.code=2) GROUP BY dd.disease
) as ddResult WHERE d.id=ddResult.disease;

SELECT TOP 3 d.name, ddResult.percentage FROM Disease d, (
	SELECT dd.disease , convert(decimal(4, 2), (convert(decimal, COUNT(*)) / convert(decimal, (
		SELECT COUNT(*) FROM DiseaseDetail WHERE disease=dd.disease)
	))) * 100 as percentage
	FROM DiseaseDetail dd WHERE (dd.axe='AX01' AND dd.code=2) OR (dd.axe='AX05' AND dd.code=2) GROUP BY dd.disease
) as ddResult WHERE d.id=ddResult.disease;

SELECT TOP 3 d.name, (ddResult.percentage - (d.probaOrder - 1) * 5) as percentage FROM Disease d, (
	SELECT dd.disease , convert(decimal(4, 2), (convert(decimal, COUNT(*)) / convert(decimal, (
		SELECT COUNT(*) FROM DiseaseDetail WHERE disease=dd.disease
	)))) * 100 as percentage
	FROM DiseaseDetail dd WHERE (dd.axe='AX01' AND dd.code=2) OR (dd.axe='AX05' AND dd.code=2) GROUP BY dd.disease
) as ddResult WHERE d.id=ddResult.disease AND d.gender=-1 AND d.lowerAge<=0 AND d.upperAge>=0 ORDER BY ddResult.percentage DESC , d.probaOrder ASC;

/* GENERATED QUERY */

SELECT TOP 3 d.name, ddResult.percentage FROM Disease d, (SELECT dd.disease , convert(decimal(4, 2), (convert(decimal, COUNT(*)) / convert(decimal, (SELECT COUNT(*) FROM DiseaseDetail WHERE disease=dd.disease)))) * 100 as percentage FROM DiseaseDetail dd WHERE (dd.axe='AX01' AND dd.code=2) OR  GROUP BY dd.disease) as ddResult WHERE d.id=ddResult.disease AND d.gender = -1 ORDER BY ddResult.percentage, d.probaOrder;

/* TEST 2 */

UPDATE Axe SET marginSimilar = 0.096 WHERE id = 'AX02';

DELETE FROM Config;
DELETE FROM Patient;

SELECT * FROM Patient;
SELECT * FROM Axe;
SELECT * FROM Config;