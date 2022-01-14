//간단한 포켓몬 게임 만들기
//플레이어가 보기 중에서 올바르게 입력했다는 가정하에 작성

//?: 입력받기 전에 '>'와 같은 걸 붙일 순 없을까?
//?: 어떻게 하나하나 공격력과 체력을 만들어줄 수 있을까
//?: 중복 포켓몬을 잡으면 이름이 같아 구분하기도 힘들텐데 그건 어떻게 할까
/*
1. 트레이너는 처음 포켓몬이 하나 주어진다.
2. 트레이너가 가고 싶은 지역 선택
3. 해당 지역에 포켓몬을 만나고 쓰러뜨리면, 해당 포켓몬 획득 가능
4. 획득한 포켓몬은 싸우기 전에 결정 가능
*/


using System;
using System.Collections.Generic;

namespace Gamp22_UnityBasic {
    /*전역 리스트 선언*/
    //다양한 마을에서 포켓몬을 얻어야 하므로 지닌 포켓몬 리스트 전역 선언
    public static class Global {
        public static List<string> poketmonlist = new List<string>(); //전역선언과 리스트 선언

        public static string[] bossarray = new string[] {"백솜모카", "갈가부기", "나인테일", "두랄로돈"};
        public static int gtown = 0; //선택한 장소와 맞는 배열을 확인하기 위한 변수

        //구현못함
        public static int gHP = 20; //스타팅 포켓몬 HP 변수
        public static int gAttack = 5; //스타팅 포켓몬의 공격력 변수
        public static int gHP2 = 20; //백솜모카 HP 변수
        public static int gAttack2 = 5; //백솜모카 공격력 변수
        public static int gHP3 = 30; //갈가부기 HP 변수
        public static int gAttack3 = 6; //갈가부기 공격력 변수
        public static int gHP4 = 40; //나인테일 HP 변수
        public static int gAttack4 = 8; //나인테일 공격력 변수
        public static int gHP5 = 50; //두랄로돈 HP 변수
        public static int gAttack5 = 10; //두랄로돈 공격력 변수
    }


    class Program {
        static void Main(string[] args) {
            StartingMain();
            LocationMain();
            recoveryMain();
            //battleMain();

            string line = string.Join(",", Global.poketmonlist.ToArray()); //리스트 출력 형식
            Console.WriteLine("\n지닌 포켓몬: " + line);
            Console.WriteLine("숫자: " + Global.gtown);
            Console.WriteLine("보스: " + Global.bossarray[Global.gtown]);
        }


        /*스타팅 포켓몬 정하기*/
        //세 가지의 포켓몬 제시
        //플레이어가 선택한 포켓몬으로 모험
        static void StartingMain() {
            int nnext = 0; //스타팅 포켓몬 결정하면 반복문을 종료하기 위한 변수
            Console.WriteLine(" ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
            Console.WriteLine("|오박사: 바깥은 혼자 돌아다니기엔 위험하단다!" +
                " 이 아이들 중 하나를 데려가렴. |");

            while (nnext == 0)
            {
                Console.WriteLine("|        누구를 선택할래? {염버니 / 울머기 / 흉나숭}                        |");
                Console.WriteLine(" ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
                string nSelect = Console.ReadLine();

                Console.WriteLine("\n\n ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
                Console.WriteLine("|오박사: " + nSelect + "(을)를 고를 거니? {예 / 아니요}                              |");
                Console.WriteLine(" ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
                string nSelect2 = Console.ReadLine();
                if (nSelect2 == "예")
                {
                    Console.WriteLine("\n\n ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
                    Console.WriteLine("|*" + nSelect + "(으)로 정했다!*                                                     |");
                    Console.WriteLine(" ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
                    nnext = 1;
                    Global.poketmonlist.Add(nSelect);
                }
                else
                {
                    Console.WriteLine("\n\n ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
                    Console.WriteLine("|오박사: 천천히 생각해도 좋고!                                              |" +
                        "\n|        감에 맡겨도 좋아!                                                  |");
                }
            }
        }


        /*모험 떠나기*/
        //4 곳의 마을 제시
        static void LocationMain() {
            int nnext = 0;//장소를 결정하면 반복문을 종료하기 위한 변수
            Console.WriteLine("\n\n ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
            Console.WriteLine("|*이제 모험을 떠나자*                                                       |");
            Console.WriteLine(" ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");

            while (nnext == 0)
            {
                Console.WriteLine("\n\n ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
                Console.WriteLine("|*어느 마을로 가볼까? {터프마을 / 바우마을 / 엔진시티 / 너클시티 / 회복센터}|");
                Console.WriteLine(" ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
                string nSelect = Console.ReadLine();

                Console.WriteLine("\n\n ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
                Console.WriteLine("|*" + nSelect + "까지 공중날기택시로 이동하겠습니까? {예 / 아니요}*                |");
                Console.WriteLine(" ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
                string nSelect2 = Console.ReadLine();
                if (nSelect2 == "예")
                {
                    Console.WriteLine("\n\n ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
                    Console.WriteLine("|*" + nSelect + "로 떠납니다.*                                                     |");
                    Console.WriteLine(" ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
                    nnext = 1;
                    if (nSelect == "터프마을")
                        Global.gtown = 0;
                    else if (nSelect == "바우마을")
                        Global.gtown = 1;
                    else if (nSelect == "엔진시티")
                        Global.gtown = 2;
                    else if (nSelect == "너클시티")
                        Global.gtown = 3;
                    else
                        Global.gtown = 4;
                }
            }
        }


        /*포켓몬 HP 회복*/
        //회복센터에서만 가능
        //지니고 있는 모든 포켓몬의 HP 회복
        static void recoveryMain() {
            Console.WriteLine("\n\n ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
            Console.WriteLine("|간호순: 안녕하세요! 포켓몬센터입니다.                                      |");
            Console.WriteLine("|        당신의 포켓몬을 쉬게 해 주겠습니다.                                |");
            Console.WriteLine("|        잠시만 기다려주세요!                                               |");
            Console.WriteLine(" ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");

            Console.WriteLine("\n\n ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");
            Console.WriteLine("|간호순: 맡겨 두신 포켓몬이 건강해졌습니다!                                 |");
            Console.WriteLine("|        또 이용해 주세요!                                                  |");
            Console.WriteLine(" ㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡㅡ");

            int nnext = 0;//모든 포켓몬 치료가 끝나면 반복문을 종료하기 위한 변수
            while (nnext < Global.poketmonlist.Count) {
                Console.WriteLine("!!!!!!!!!!11구 현 못 함!!!!!!!!!!!!!!!!!!");
                nnext++;
            }
        }


        /*전투*/
        //해당 마을의 포켓몬과 포켓몬의 HP 제시 후 전투 여부 묻기
        //동의한다면 
        static void battleMain() {

        }
    }
}
