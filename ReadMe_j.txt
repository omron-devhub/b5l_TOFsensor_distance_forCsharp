------------------------------------------------
 B5L 結果取得サンプルコード （C#版）
------------------------------------------------

（1）サンプルコード内容
  本サンプルは、B5L(3D TOFセンサモジュール)のC#による結果取得サンプルコードを提供します。
  サンプルコードでは、「測距開始」、「測距停止」、「結果取得」を実行できます。

  注)本サンプルコードは、お客様でコーディングされる際の参考用としてご利用ください。
     結果取得フォーマット設定が距離データ(極座標形式)の場合のみに限り、
     ビルド後のexeファイル実行後に表示されるGUI画面上の「Output CSV」チェックボックスをONにすることで、
     結果取得されたデータをCSV形式でファイル出力することが可能です。
     (GUI画面上のConnectボタン押下時に結果取得フォーマットが距離データ(極座標形式)に設定されます)

     性能評価をされる場合は、下記のURLより評価用ソフトウェアをダウンロードしてご利用ください。
     https://www.omron.co.jp/ecb/sensors/displacement-sensors_ranging-sensors/3D-TOF-sensor-module/B5L_licence

（2）ファイル説明
  TOFSensorSampleGetResult/フォルダーには、次のファイルが存在します。

    bin/                                    ビルド用の出力ディレクトリ
    Properties/                             プロジェクト設定のデータ保存ディレクトリ
    FormMain.cs                             サンプルコード本体
    FormMain.Designer.cs                    フォーム画面のデザイン定義ファイル
    FormMain.resx                           フォーム画面のXMLリソースファイル
    Program.cs                              アプリケーションのメインエントリポイント。
    TOFCommand.cs                           コマンドクラス
    TOFSensorSampleGetResult.csproj         プロジェクトファイル。
    TOFSerialPort.cs                        シリアルポートの接続/切断/送信/受信クラス

（3）サンプルコードのビルド方法
  1.本サンプルコードは、Windows 10上で動作するようにビルドされています。
     Visual Studio 2015(C#.NET)でコンパイルおよびリンクできます。
  2. exeファイルは、コンパイル後にTOFSensorSampleGetResult / binの下に生成されます。
     exeの実行には、.NET Framework 4.5以上が必要です。

【使用上の注意】
* 本サンプルコードおよびドキュメントの著作権はオムロンに帰属します。
* 本サンプルコードは動作を保証するものではありません。
* 本サンプルコードは、Apache License 2.0にて提供しています。

----
オムロン株式会社
Copyright 2020-2021 OMRON Corporation、All Rights Reserved.
