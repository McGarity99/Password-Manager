create database MasPass;

use MasPass;

CREATE TABLE maspass(
    ID varchar(12) NOT NULL PRIMARY KEY AUTO_INCREMENT,
    MasPass varchar(15) NOT NULL,
);

insert into maspass values('Password');