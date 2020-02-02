use bai_tap;
go

--1.them cot trang thai bang mon an
alter table MONAN add trangthai int;
go

--2.xoa nhan vien co ma nhan vien > 34
delete NHANVIEN where MANHANVIEN > 34;
go

--3.bien cuc bo 
DECLARE @KhachHangId int;
SET @KhachHangId = 10;

SELECT *
FROM   KHACHHANG
WHERE  MAKHACHHANG > @KhachHangId;

--4.cap nhat ten ban thanh ten nhan vien neu co id ban trung voi id nhan vien
UPDATE BANAN 
SET LOAIBAN = (SELECT TENNHANVIEN
          FROM NHANVIEN
          WHERE NHANVIEN.MANHANVIEN = BANAN.ID_MANHANVIEN)
WHERE MABAN > 20;
go

--5.in ra ten khach hang va ten
DECLARE @temp_CustID int, @temp_name
varchar(50)
SET @temp_CustID = 12
SELECT @temp_name = TENKHACHHANG FROM KHACHHANG
Where MAKHACHHANG = @temp_CustID
PRINT 'KhachHangID is'  + @temp_CustID +  'and Name is' +
@temp_name

--6. cap nhat ten kahch hang co id = 25. neu ko co in ra dong ko dc cap nhat
Update KHACHHANG set TENKHACHHANG = N'Ronaldo'
Where MAKHACHHANG =25
If(@@rowcount=0)
	begin
		print N'Không dòng nào được cập nhật'
	return
end

--7.in ra cac muc giam gia mon an trong bang mon an
SELECT MAMON, DONGIA,[discount%]=
CASE
	WHEN DONGIA <20000 THEN 10
	WHEN DONGIA BETWEEN 20000 and 50000 THEN 15
	WHEN DONGIA BETWEEN 50000 and 1000000 THEN 20
	ELSE
		0.0
	END
FROM MONAN
ORDER BY MAMON

--8.tang gap doi don gia cua mon an co gia < 50000
WHILE (SELECT AVG(DONGIA) FROM MONAN) < 50000
	BEGIN
	UPDATE MONAN SET DONGIA = DONGIA * 2
	IF (SELECT MAX(DONGIA) FROM MONAN) > 50000
		BREAK
	ELSE
		CONTINUE
END

--9.bien toan cuc
select @@VERSION,@@SERVERNAME,@@ERROR ;
go

--10.in ra loai mon cua tung ma mon
SELECT MAMON,LOAIMON =
CASE ID_MANHOM
	WHEN 1 THEN N'tráng miệng'
	WHEN 2 THEN N'món chính'
	WHEN 3 THEN N'món phụ'
	WHEN 4 THEN N'món khai vị'
	WHEN 5 THEN N'hoa quả'
	ELSE N'chưa phân nhóm'
END
FROM MONAN
ORDER BY ID_MANHOM

--11.tao thu tuc lay du lieu khach hang
CREATE PROC KhachHangTimKiem
@cus_id int = NULL
AS
SELECT MAKHACHHANG, TENKHACHHANG, SDT
FROM KHACHHANG
WHERE MAKHACHHANG like @cus_id
RETURN (@@rowcount)
GO

--12.tao thu tuc dat lai gia moi cho mon an
create proc MonAn_Update @mamon int,@giamoi float
as
update MONAN
set DONGIA=@giamoi
where MAMON=@mamon
go

--thuc thi
MonAn_Update 2,20000;
go

--13.lay ra cac khach hang co ma khach hang tuy y
create function f_SelectCustomer
(@customerid int)
returns table
as
return (select * from KHACHHANG
where MAKHACHHANG > @customerid)
go

--14.xoa 3 nnhan vien dau tien co chua tu 'minh' trong ten
DELETE TOP(3) 
FROM NHANVIEN
WHERE TENNHANVIEN = '%Minh%';
GO

--15.dung con tro hien tat ca thong tin khach hang
DECLARE @id int
DECLARE @name nvarchar(200)


DECLARE cursorCustomer CURSOR FOR  
SELECT MAKHACHHANG, TENKHACHHANG FROM KHACHHANG    

OPEN cursorCustomer                

FETCH NEXT FROM cursorCustomer     
      INTO @id, @name

WHILE @@FETCH_STATUS = 0          
BEGIN
    --In kết quả
    PRINT 'ID:' + CAST(@id as varchar);
    PRINT 'Ten khach Hang:' + @name;

    FETCH NEXT FROM cursorCustomer 
          INTO @id, @name
END

CLOSE cursorCustomer              
DEALLOCATE cursorCustomer         
