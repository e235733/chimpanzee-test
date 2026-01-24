# Chimpanzee Test

Unityで制作した、Webブラウザで遊べる記憶力ゲームです。
PCでの動作に対応しています。

![Unity](https://img.shields.io/badge/Unity-6000.3-black.svg?style=flat&logo=unity)
![License](https://img.shields.io/badge/License-MIT-blue.svg)

## Demo

以下のリンクからブラウザ上でプレイできます（ダウンロード不要）。

**[Chimpanzee Test (Vercel)](https://chimpan-test.vercel.app/)**

## Controls

**UI操作** : クリック

## Features

*   **難易度の上昇**
    *   画面上に表示される数字の数が増加していきます。最初は3個、最大8個の数字が表示されます。
*   **ランダムな配置**
    *   毎ゲーム、数字のボックスがランダムな位置に再配置されます。その際、それぞれの数字の位置は重なりません。
*   **記憶力テスト**
    *   ゲーム開始から3秒後に数字が隠れ、1から順番にクリックしていく必要があります。全ての難易度において順番通りにクリックするとクリアです。
*   **ゲームサイクル**
    *   `GameManager` によるゲームステートの管理。
    *   TextMeshProを使用した視認性の高いUI。

## Tech Stack

*   **Engine:** Unity [6000.3.2f1]
*   **Language:** C#
*   **IDE:** Visual Studio Code
*   **Deploy:** WebGL

## Architecture

主なスクリプトの役割：

*   `GameManager.cs`: ゲーム全体の進行管理、スタート・終了画面の表示、レベル管理。
*   `ContainerManager.cs`: 各レベルのセットアップ、数字ボックスの生成とランダム配置、正誤判定。
*   `BoxController.cs`: 数字の表示・非表示の制御、クリックイベントの処理。

## How to Run Locally

1.  このリポジトリをクローンします。
    ```bash
    git clone https://github.com/e235733/chimpanzee-test
    ```
2.  Unity Hubを開き、「Add (追加)」からクローンしたフォルダを選択します。
3.  プロジェクトを開き、`Assets/Scenes/Game.unity` を再生します。

## License

This project is licensed under the MIT License.
