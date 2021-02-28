--Команды для объявления и инициализации базы данных
Create database TestAppDB;
Create table Test(
    Id serial primary key,
    Name text not null,
    CreationDate date not null
);
Create table Question(
	Id serial primary key,
	QuestionBody text not null,
	Answer1 text not null,
	Answer2 text not null,
	Answer3 text not null,
	RigthAnswer integer not null,
	TestId integer,
	FOREIGN KEY (TestId) REFERENCES Test (Id)
);
Create table Person (
	Id serial primary key,
	Name text,
	Email text,
	Password text
);
Create table CompletedTest(
	Id serial primary key,
	Date date not null,
	TestId integer not null,
	PersonId integer not null,
	FOREIGN KEY (TestId) REFERENCES Test (Id),
	FOREIGN KEY (PersonId) REFERENCES Person (Id)
);
Create table Answer(
	Id serial primary key,
	QuestionId integer not null,
	Value integer not null,
	CompletedTestId integer not null,
	FOREIGN KEY (QuestionId) REFERENCES Question (Id),
	FOREIGN KEY (CompletedTestId) REFERENCES CompletedTest (Id)
);

Insert into Test(Name, CreationDate)
	Values 
	('AnimalTest', '2021-02-25'),
	('MathTest', '2021-02-25'),
	('LiteratureTest', '2021-02-25');

Insert into Question(QuestionBody, Answer1, Answer2, Answer3, Rigthanswer, testid) Values
('Who Can Fly', 'bird', 'cat', 'fish', 1, 1),
('Who Can Walk', 'bird', 'cat', 'fish', 2, 1),
('Who Can Swim', 'bird', 'cat', 'fish', 3, 1);
('2+2=?', '4', '5', '8', 1, 2),
('100-7=?', '92', '93', '94', 2, 2),
('33+77=?', '110', '100', '111', 1, 2),
('Автор хотел назвать свою героиню Наташей, но потом передумал и дал ей «простонародное», старомодное имя. Героиня «была нетороплива, Не холодна, не говорлива…», мечтательна и чиста', 'Татьяна Ларина', 'Бедная Лиза', 'Анна Каренина', 1, 3),
('Самый ленивый помещик из Петербурга, не занимался ничем, кроме рассуждений', 'Степан Плюшкин', 'Илья Обломов', 'Пьер Безухов', 2, 3),
('Герой, страдающий максимализмом, имеет незаурядный ум, постоянно «алчущий познаний». Он возвращается из-за границы к своей возлюбленной, которую не видел три года', 'Павел Фамусов', 'Простаков', 'Александр Чацкий', 3, 3);

insert into person(name, email, password) values
('Dima', 'dime@mail.ru', 1111),
('Vova', 'vovan@mail.ru', 1111);
