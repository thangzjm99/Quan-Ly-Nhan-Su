use new_data;
go
--1. thêm cột email vào bảng khách hàng
alter table KHACHHANG add email varchar(255) ;
go
--2. xóa cột email trong bảng khách hàng
ALTER TABLE KHACHHANG
DROP COLUMN email;
--3. xóa hết dữ liệu của bảng món ăn
TRUNCATE TABLE MONAN;
--4 .tạo một bảng tên YEUCAUTHANHTOAN 
CREATE TABLE YEUCAUCUATHANHTOAN (
	NAME varchar(255) NOT NULL,
    CACHTHANHTOAN varchar(255)NOT NULL UNIQUE,
    HOADONDO varchar(255) UNIQUE,
    LOAITIEN varchar(255) DEFAULT 'VIETNAM DONG'
    
);
--5.Cho biết tình trạng của bảng bàn ăn đều đã được đặt(1 = tình trạng còn bàn) 
insert into BANAN(MABAN,ID_MANHANVIEN,LOAIBAN,TINHTRANG)
select BA.MABAN,BA.ID_MANHANVIEN,BA.LOAIBAN, 1
from BANAN BA
where BA.TINHTRANG = 0

--6.CHo biết và thêm dữ liệu của bà ăn Nếu như mã nhân viên > 3 
DECLARE @ID_MANHANHVIEN integer;
DECLARE @MABAN integer;
DECLARE @LOAIBAN varchar(50);
DECLARE @TINHTRANG integer;
 
DECLARE BANAN_Cursor CURSOR FOR
SELECT
BA.MABAN,
BA.ID_MANHANVIEN,
BA.LOAIBAN
 
FROM BANAN BA
WHERE BA.ID_MANHANVIEN > 3;

--7.Tính thành tiền của hóa đơn bằng mã món và phần trăm hóa đơn được discount
SELECT MATHANHTOAN,THANHTIEN ,[THANHTIEN/discount(%) ] =
CASE ID_MAMON
	WHEN 1 THEN N'20000 / 10' 
	WHEN 2 THEN N'10000 / 20' 
	WHEN 3 THEN N'30000 / 30' 
	WHEN 4 THEN N'50000 / 40' 
	WHEN 5 THEN N'60000 / 50' 
ELSE N'100000 / 60'
END
FROM DONGTHANHTOAN
ORDER BY ID_MAMON
--8. Cập nhật các bàn còn trống cho người quản lí . Nếu bàn còn được sử dụng thì in ra "Không còn bàn trống "
UPDATE BANAN SET TINHTRANG = 0  
WHERE MABAN BETWEEN 5 and 15 
IF (@@ROWCOUNT = 0)
BEGIN
	PRINT 'KHÔNG CÒN BÀN TRỐNG'
RETURN
END
--9. Biến toàn cục
SELECT @@VERSION,@@SERVERNAME,@@ERROR;
GO
--10 . Lấy địa chỉ và tên của khách hàng rồi in ra màn hình .
DECLARE @DIA_CHI varchar(40), @TEN_TUOI varchar(20)

	DECLARE KHACHANG_Cursor CURSOR FOR 
	SELECT DIACHI , TENKHACHHANG FROM DBO.KHACHHANG

	OPEN KHACHHANG_Cursor 

	FETCH NEXT FROM KHACHHANG_Cursor INTO @DIA_CHI, @TEN_TUOI 
	WHILE @@FETCH_STATUS = 0 
	BEGIN 
		PRINT 'SDT:' + @DIA_CHI + ' ' + @TEN_TUOI
		FETCH NEXT FROM KHACHHANG_Cursor INTO @DIA_CHI, @TEN_TUOI
	END
	CLOSE KHACHHANG_Cursor
 
	DEALLOCATE KHACHHANG_Cursor
 --11 . Tạo ra cơ sở để tìm kiếm bàn còn trống nhanh nhất cho khách hàng 
 CREATE PROC TIM_KIEM_BAN_TRONG @TIM_BAN INT NULL
AS
SELECT ID_MANHANVIEN,MABAN,TINHTRANG
FROM BANAN
WHERE TINHTRANG LIKE @TIM_BAN
RETURN (@@rowcount)
GO
--THỰC THI
TIM_KIEM_BAN_TRONG 0;
GO

--12. Tìm ra top 3 nhân viên của tháng biết rằng lấy theo thứ tự đã nhập
DECLARE @nhanviencuathang int;
SET @nhanviencuathang = 4;

SELECT *FROM NHANVIEN   
WHERE  MANHANVIEN < @nhanviencuathang;

