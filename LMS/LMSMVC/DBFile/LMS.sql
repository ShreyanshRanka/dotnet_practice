alter user 'root'@'localhost' identified with mysql_native_password by 'root123';
flush privileges;

create database LMS;
use LMS;

create table Training(
    id int primary key,
    topic varchar(50),
    descriptions varchar(50),
    faculty varchar(50),
    location varchar(50)
);

insert into Training values(1, 'dotnet', 'dotnet-mvc', 'ravi tambade', '401');
insert into Training values(2, 'java', 'spring-mvc', 'madhura', '401');
insert into Training values(3, 'dsa', 'tree', 'vishal jagtap', '401');
insert into Training values(4, 'wpt', 'react', 'kishori', '401');
insert into Training values(3, 'os', 'mutex', 'nisarg', '401');

