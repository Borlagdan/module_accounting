DROP DATABASE IF EXISTS capstone_sis;

CREATE DATABASE capstone_sis;
USE capstone_sis;


DROP TABLE IF EXISTS students;

CREATE TABLE students(
	student_id INTEGER NOT NULL AUTO_INCREMENT,
	student_number VARCHAR(20),
	grade_level VARCHAR(20),
	section VARCHAR(20),
	last_name VARCHAR(20),
	first_name VARCHAR(20),
	middle_name VARCHAR(20),
	gender VARCHAR(10),
	address VARCHAR(50),
	contact VARCHAR(11),
	parent_guardian_number VARCHAR(20),
	enrolled_date VARCHAR(20),
	PRIMARY KEY(student_id)
);

INSERT INTO students (student_number, grade_level, section, last_name, first_name, middle_name, gender, address, contact, parent_guardian_number, enrolled_date) VALUES 
('S_0001', 'Grade 7', 'Section 1', 'Stark', 'Arya', '?', 'Female', 'The North', '09243355432', 'P_0001', '05/29/2017'),
('S_0002', 'Grade 7', 'Section 4', 'Stark', 'Sansa', '?', 'Female', 'The North', '09125443356', 'P_0001', '05/31/2017'),
('S_0003', 'Grade 7', 'Section 2', 'Stark', 'Brandon', '?', 'Male', 'The North', '09173345234', 'P_0001', '05/29/2017'),
('S_0004', 'Grade 8', 'Section 1', 'Lannister', 'Jaime', '?', 'Male', 'The Westerlands', '09106654574', 'P_0002', '05/30/2017'),
('S_0005', 'Grade 8', 'Section 1', 'Lannister', 'Cersei', '?', 'Female', 'The Westerlands', '09116654257', 'P_0002', '05/30/2017'),
('S_0006', 'Grade 9', 'Section 4', 'Lannister', 'Tyrion', '?', 'Male', 'The Westerlands', '09932222454', 'P_0002', '05/29/2017');


DROP TABLE IF EXISTS parent_guardian;

CREATE TABLE parent_guardian(
	parent_guardian_id INTEGER NOT NULL AUTO_INCREMENT,
	parent_guardian_number VARCHAR(20),
	last_name VARCHAR(20),
	first_name VARCHAR(20),
	middle_name VARCHAR(20),
	gender VARCHAR(10),
	address VARCHAR(50),
	contact VARCHAR(11),
	PRIMARY KEY(parent_guardian_id)
);

INSERT INTO parent_guardian (parent_guardian_number, last_name, first_name, middle_name, gender, address, contact) VALUES
('P_0001', 'Stark', 'Eddard', '?', 'Male', 'The North', '09212253421'),
('P_0002', 'Lannister', 'Tywin', '?', 'Male', 'The Westerlands', '09125344234');


DROP TABLE IF EXISTS fees;

CREATE TABLE fees(
	fee_id INTEGER NOT NULL AUTO_INCREMENT,
	fee_type VARCHAR(20),
	fee_amount DOUBLE,
	covered TEXT,
	remarks VARCHAR(30),
	PRIMARY KEY(fee_id)
);	

INSERT INTO fees (fee_type,fee_amount, covered, remarks) VALUES
('Registration', 500, 'Kinder I, Kinder II', 'Fee for one School Year'),
('Registration', 3000, 'Grade 1, Grade 2, Grade 3', 'Fee for one School Year'),
('Registration', 2000, 'Grade 4, Grade 5', 'Fee for one School Year'),
('Registration', 3000, 'Grade 6, Grade 7, Grade 8, Grade 9, Grade 10', 'Fee for one School Year'),
('Registration', 2000, 'Grade 11, Grade 12', 'Fee for one School Year'),
('Tuition', 4200, 'Kinder I, Kinder II', 'Fee for one School Year'),
('Tuition', 7100, 'Grade 1, Grade 2, Grade 3, Grade 4, Grade 5, Grade 6', 'Fee for one School Year'),
('Tuition', 8100, 'Grade 7, Grade 8, Grade 9, Grade 10', 'Fee for one School Year'),
('Tuition', 4000, 'Grade 11, Grade 12', 'Fee for one School Year'),
('Computer/Elective', 0, 'Kinder II, Kinder II', 'Fee for one School Year'),
('Computer/Elective', 400, 'Grade 1, Grade 2, Grade 3', 'Fee for one School Year'),
('Computer/Elective', 500, 'Grade 4, Grade 5, Grade 6, Grade 7', 'Fee for one School Year'),
('Computer/Elective', 1100, 'Grade 8, Grade 9, Grade 10', 'Fee for one School Year'),
('Computer/Elective', 1000, 'Grade 11, Grade 12', 'Fee for one School Year'),
('Miscellaneous', 3000, 'Kinder I, Kinder II', 'Fee for one School Year'),
('Miscellaneous', 2000, 'Grade 1, Grade 2, Grade 3, Grade 4, Grade 5, Grade 6, Grade 7, Grade 8, Grade 9, Grade 10, Grade 11, Grade 12', 'Fee for one School Year');


DROP TABLE IF EXISTS accounting;

CREATE TABLE accounting(
	accounting_id INTEGER NOT NULL AUTO_INCREMENT,
	accounting_number VARCHAR(20),
	school_year VARCHAR(20),
	quarter VARCHAR(10),
	student_number VARCHAR(20),
	assessed_by VARCHAR(20),
	payment_number VARCHAR(20),
	installment_number VARCHAR(20),
	PRIMARY KEY(accounting_id)
);


DROP TABLE IF EXISTS installments;

CREATE TABLE installments(
	installment_id INTEGER NOT NULL AUTO_INCREMENT,
	school_year VARCHAR(20),
	quarter VARCHAR(20),
	installment_number VARCHAR(20),
	count VARCHAR(2),
	assessed_by VARCHAR(20),
	student_number VARCHAR(20),
	installment_date VARCHAR(20),
	fee_type VARCHAR(20),
	fee_amount DOUBLE,
	cash_amount DOUBLE,
	installment_amount DOUBLE,
	change_amount DOUBLE,
	remaining DOUBLE,
	total DOUBLE,
	remarks VARCHAR(20),
	PRIMARY KEY(installment_id)
);


DROP TABLE IF EXISTS payments;

CREATE TABLE payments (
	payment_id INTEGER NOT NULL AUTO_INCREMENT,
	payment_number VARCHAR(20),
	school_year VARCHAR(20),
	quarter VARCHAR(20),
	assessed_by VARCHAR(20),
	payment_date VARCHAR(20),
	student_number VARCHAR(20),
	fee_type VARCHAR(20),
	fee_amount DOUBLE,
	payment_amount DOUBLE,
	remaining DOUBLE,
	total DOUBLE,
	remarks VARCHAR(20),
	PRIMARY KEY(payment_id)
);


DROP TABLE IF EXISTS balances;

CREATE TABLE balances (
	balance_id INTEGER NOT NULL AUTO_INCREMENT,
	balance_number VARCHAR(20),
	school_year VARCHAR(20),
	assessed_by VARCHAR(20),
	payment_date VARCHAR(20),
	student_number VARCHAR(20),
	fee_type VARCHAR(20),
	amount DOUBLE,
	remaining DOUBLE,
	status VARCHAR(20),
	PRIMARY KEY(balance_id)
);

INSERT INTO balances (balance_number, school_year, assessed_by, payment_date, student_number, fee_type, amount, remaining, status) VALUES
('B_0001', '2017-2018', 'Admin', '', 'S_0001', 'Miscellaneous', 2000, 2000, 'Payment incomplete'),
('B_0002', '2017-2018', 'Admin', '', 'S_0001', 'Tuition', 8100, 8100, 'Payment incomplete'),
('B_0003', '2017-2018', 'Admin', '', 'S_0002', 'Miscellaneous', 2000, 2000, 'Payment incomplete'),
('B_0004', '2017-2018', 'Admin', '', 'S_0002', 'Tuition', 8100, 8100, 'Payment incomplete'),
('B_0005', '2017-2018', 'Admin', '', 'S_0003', 'Miscellaneous', 2000, 2000, 'Payment incomplete'),
('B_0006', '2017-2018', 'Admin', '', 'S_0003', 'Tuition', 8100, 8100, 'Payment incomplete'),
('B_0007', '2017-2018', 'Admin', '', 'S_0004', 'Miscellaneous', 2000, 2000, 'Payment incomplete'),
('B_0008', '2017-2018', 'Admin', '', 'S_0004', 'Tuition', 8100, 8100, 'Payment incomplete'),
('B_0009', '2017-2018', 'Admin', '', 'S_0005', 'Miscellaneous', 2000, 2000, 'Payment incomplete'),
('B_0010', '2017-2018', 'Admin', '', 'S_0005', 'Tuition', 8100, 8100, 'Payment incomplete'),
('B_0011', '2017-2018', 'Admin', '', 'S_0006', 'Miscellaneous', 2000, 2000, 'Payment incomplete'),
('B_0012', '2017-2018', 'Admin', '', 'S_0006', 'Tuition', 8100, 8100, 'Payment incomplete');


DROP TABLE IF EXISTS books;

CREATE TABLE books(
	book_id INTEGER NOT NULL AUTO_INCREMENT,
	school_year VARCHAR(20),
	book_number VARCHAR(20),
	title VARCHAR(50),
	subject VARCHAR(50),
	covered VARCHAR(120),
	amount DOUBLE,
	PRIMARY KEY(book_id)
);

INSERT INTO books (school_year, book_number, title, subject, covered, amount) VALUES ('2017-2018', 'book_001', 'Filipino', 'Filipino', 'Grade 1, Grade 2, Grade 3, Grade 4, Grade 5, Grade 6, Grade 7, Grade 8, Grade 9, Grade 10, Grade 11, Grade 12', 500);
INSERT INTO books (school_year, book_number, title, subject, covered, amount) VALUES ('2017-2018', 'book_002', 'English', 'English', 'Grade 1, Grade 2, Grade 3, Grade 4, Grade 5, Grade 6, Grade 7, Grade 8, Grade 9, Grade 10, Grade 11, Grade 12', 500);
INSERT INTO books (school_year, book_number, title, subject, covered, amount) VALUES ('2017-2018', 'book_003', 'Mathematics', 'Mathematics', 'Grade 1, Grade 2, Grade 3, Grade 4, Grade 5, Grade 6, Grade 7, Grade 8, Grade 9, Grade 10, Grade 11, Grade 12', 500);
INSERT INTO books (school_year, book_number, title, subject, covered, amount) VALUES ('2017-2018', 'book_004', 'Science', 'Science', 'Grade 1, Grade 2, Grade 3, Grade 4, Grade 5, Grade 6, Grade 7, Grade 8, Grade 9, Grade 10, Grade 11, Grade 12', 500);
INSERT INTO books (school_year, book_number, title, subject, covered, amount) VALUES ('2017-2018', 'book_005', 'Araling Panlipunan', 'Araling Panlipunan', 'Grade 7, Grade 8, Grade 9, Grade 10, Grade 11, Grade 12', 500);
INSERT INTO books (school_year, book_number, title, subject, covered, amount) VALUES ('2017-2018', 'book_006', 'Edukasyon sa Pagpapakatao (EsP)', 'Edukasyon sa Pagpapakatao (EsP)', 'Grade 1, Grade 2, Grade 3, Grade 4, Grade 5, Grade 6', 500);
INSERT INTO books (school_year, book_number, title, subject, covered, amount) VALUES ('2017-2018', 'book_007', 'MAPEH', 'MAPEH', 'Grade 1, Grade 2, Grade 3, Grade 4, Grade 5, Grade 6', 500);
INSERT INTO books (school_year, book_number, title, subject, covered, amount) VALUES ('2017-2018', 'book_008', 'Edukasyong Pantahanan at Pangkabuhayan (EPP)', 'Edukasyong Pantahanan at Pangkabuhayan (EPP)', 'Grade 1, Grade 2, Grade 3, Grade 4, Grade 5, Grade 6', 500);
INSERT INTO books (school_year, book_number, title, subject, covered, amount) VALUES ('2017-2018', 'book_009', 'Technology and Livelihood Education (TLE)', 'Technology and Livelihood Education (TLE)', 'Grade 7, Grade 8, Grade 9, Grade 10, Grade 11, Grade 12', 500);

/*
Queries:


Display Student's Parent/Guardian Information
SELECT CONCAT(parent_guardian.last_name, ', ', parent_guardian.first_name) AS 'Parent / Guardian', parent_guardian.contact AS 'Contact' FROM parent_guardian WHERE parent_guardian.parent_guardian_number = '130144';

Display Student's Payables
SELECT fees.fee_type, fees.fee_amount FROM fees, students WHERE fees.covered = (SELECT students.grade_level FROM students WHERE students.student_number = '13-0144');

Display Student's Buyable Books
SELECT books.title, books.subject, books.amount FROM books WHERE books.covered LIKE CONCAT('%',(SELECT students.grade_level FROM students WHERE students.student_number = '13-0144'),'%');

*/

