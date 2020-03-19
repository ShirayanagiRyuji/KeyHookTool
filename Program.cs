using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyHoldTool
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        /// <remarks>
        /// Mutex https://dobon.net/vb/dotnet/process/checkprevinstance.html
        /// </remarks>
        [STAThread]
        static void Main()
        {
            // Mutexクラスの作成
            System.Threading.Mutex mutex = new System.Threading.Mutex(false, "KeyHoldTool");
            bool hasHandle = false;

            try
            {
                try
                {
                    //ミューテックスの所有権を要求する
                    hasHandle = mutex.WaitOne(0, false);
                }
                catch (System.Threading.AbandonedMutexException)
                {
                    //別のアプリケーションがミューテックスを解放しないで終了した時
                    hasHandle = true;
                }

                if (hasHandle == false)
                {
                    // すでに起動していると判断して終了
                    // すてに起動しているアプリを通常サイズで最前面へ
                    System.Diagnostics.Process prevProcess = GetPreviousProcess();
                    if (prevProcess != null)
                    {
                        WakeupWindow(prevProcess.MainWindowHandle);
                    }

                    return;
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormMain());
            }
            finally
            {
                if (hasHandle)
                {
                    //ミューテックスを解放する
                    mutex.ReleaseMutex();
                }
                mutex.Close();
            }
        }

        // 外部プロセスのメイン・ウィンドウを起動するためのWin32 API
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool IsIconic(IntPtr hWnd);

        /// <summary>
        /// ShowWindowAsync関数のパラメータに渡す定義値
        /// </summary>
        private const int SW_RESTORE = 9;  // 画面を元の大きさに戻す

        /// <summary>
        /// 外部プロセスのウィンドウを起動する
        /// </summary>
        /// <param name="hWnd"></param>
        /// <remarks>
        /// https://www.atmarkit.co.jp/fdotnet/dotnettips/151winshow/winshow.html
        /// </remarks>
        public static void WakeupWindow(IntPtr hWnd)
        {
            // メイン・ウィンドウが最小化されていれば元に戻す
            if (IsIconic(hWnd) == true)
            {
                ShowWindowAsync(hWnd, SW_RESTORE);
            }

            // メイン・ウィンドウを最前面に表示する
            SetForegroundWindow(hWnd);
        }

        /// <summary>
        /// 実行中の同じアプリケーションのプロセスを取得する
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// https://www.atmarkit.co.jp/fdotnet/dotnettips/151winshow/winshow.html
        /// </remarks>
        public static System.Diagnostics.Process GetPreviousProcess()
        {
            System.Diagnostics.Process curProcess = System.Diagnostics.Process.GetCurrentProcess();
            System.Diagnostics.Process[] allProcesses = System.Diagnostics.Process.GetProcessesByName(curProcess.ProcessName);

            foreach (System.Diagnostics.Process checkProcess in allProcesses)
            {
                // 自分自身のプロセスIDは無視する
                if (checkProcess.Id != curProcess.Id)
                {
                    // プロセスのフルパス名を比較して同じアプリケーションか検証
                    if (String.Compare(
                        checkProcess.MainModule.FileName,
                        curProcess.MainModule.FileName, true) == 0)
                    {
                        // 同じフルパス名のプロセスを取得
                        return checkProcess;
                    }
                }
            }

            // 同じアプリケーションのプロセスが見つからない！
            return null;
        }
    }
}
