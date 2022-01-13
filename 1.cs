//몬스터와 플레이어 싸움 구현
//기초임으로 각각 함수가 독립임을 인지


using System;

namespace Gamp22_UnityBasic {
    class Program {
        static void Main(string[] args) {
            //ValMain();
            //PlayerAttackMain();
            //CritcalAttackMain();
            //StageMain();
            //AttackWhile();
            MonsterListMain();
        }


        //예제: 변수 선언, 데이터 저장
        static void ValMain() {
            int nScore = 0;
            float fRat = 1.0f / 4.0f;
            Console.WriteLine("Score:" + nScore);
            Console.WriteLine("Rat:" + fRat);
        }


        //변수: 데이터를 저장하는 공간
        //데이터타입: 데이터의 종류 지정  ex) int, float, bool...
        /*
         1. 플레이어가 몬스터 공격
        -몬스터의 HP와 플레이어의 공격력 선언
        -공격 후 변화 출력
        */
        static void PlayerAttackMain() {
            int nPlayerAttack = 5;
            int nMonsterHP = 50;
            Console.WriteLine("캐릭터 공격력: " + nPlayerAttack);
            Console.WriteLine("몬스터 체력: " + nMonsterHP);

            nMonsterHP = nMonsterHP - nPlayerAttack;

            Console.WriteLine("캐릭터 공격력: " + nPlayerAttack);
            Console.WriteLine("몬스터 체력: " + nMonsterHP);
        }


         //cRandom과 nRandom은 데이터타입이 다름
         //랜덤 함수 활용법 알기
         /*
          2. 크리티컬 데미지 추가
        -몬스터의 HP와 플레이어의 공격력 선언
        -일정 확률로 기존 공격력의 1.6배 데미지 증가
        -치명타가 적용되었다면 알림
        -공격 후 변화 출력
         */
        static void CritcalAttackMain() {
            int nPlayerAttack = 5;
            int nMonsterHP = 50;
            Console.WriteLine("캐릭터 공격력: " + nPlayerAttack);
            Console.WriteLine("몬스터 체력: " + nMonsterHP);

            Random cRandom = new Random();
            int nRandom = cRandom.Next(0, 5);
            if (nRandom == 0) {
                nPlayerAttack = (int)(nPlayerAttack * 1.6);
                nMonsterHP = nMonsterHP - nPlayerAttack;
                Console.WriteLine("치명타!!: " + nPlayerAttack);
                Console.WriteLine("몬스터 체력: " + nMonsterHP);
            }
            else {
                nMonsterHP = nMonsterHP - nPlayerAttack;
                Console.WriteLine("캐릭터 공격력: " + nPlayerAttack);
                Console.WriteLine("몬스터 체력: " + nMonsterHP);
            }
        }


        /*
         3. 마을이동 구현
        -장소를 플레이어에게 제시
        -장소를 직접 입력받아 이동
        -이동 후 알림
        */
        static void StageMain() {
            Console.WriteLine("어느 마을로 가시겠습니까?\n{눔바니 / 아이헨발데 / 도라도}");
            string nLocation = Console.ReadLine();

            switch(nLocation) {
                case "눔바니":
                    Console.WriteLine("얄롤리~ 눔바니로 떠납니다.");
                    break;

                case "아이헨발데":
                    Console.WriteLine("아이헨발데로 떠납니다.");
                    break;

                case "도라도":
                    Console.WriteLine("도라도로 떠납니다.");
                    break;

                default:
                    Console.WriteLine("말씀해주신 마을은 존재하지 않습니다.\n게임을 종료합니다.");
                    break;
            }
        }


        /*
         4. 몬스터가 죽을 때까지 공격 반복
        -몬스터의 HP와 플레이어의 공격력 선언
        -공격 여부를 확인
        -y일 경우 공격한 후 몬스터의 HP 변화 출력
        -n일 경우 아무 일도 일어나지 않음
        -몬스터의 HP가 0이하가 된다면 게임 종료
        */
        static void AttackWhile() {
            int nPlayerAttack = 10;
            int nMonsterHP = 50;

            while (nMonsterHP > 0) {
                Console.WriteLine("\n야생 땃쥐가 싸움을 걸어왔다.\n땃쥐의 체력: " + nMonsterHP +
                    "\n공격하시겠습니까? {y / n}");
                string nAttack = Console.ReadLine();

                switch (nAttack) {
                    case "y":
                        Console.WriteLine("땃쥐를 공격합니다. 데미지: " + nPlayerAttack);
                        nMonsterHP -= nPlayerAttack;
                        break;

                    case "n":
                        Console.WriteLine("땃쥐가 고개를 갸웃거립니다.");
                        break;

                    default:
                        Console.WriteLine("명령을 다시 내려주세요.");
                        break;
                }
            }
            Console.WriteLine("\n땃쥐의 체력 0! 야생 땃쥐는 기절했다...");
        }


        /*
         5. 플레이어나 몬스터 한쪽이 사망할 때까지 반복
        -몬스터의 HP와 플레이어의 공격력 선언
        -공격 여부를 확인
        -y일 경우 공격한 후 몬스터의 HP 변화 출력
        -n일 경우 아무 일도 일어나지 않음
        -몬스터의 HP가 0이하가 된다면 게임 종료
        */
        static void MonsterListMain() {

        }
    }
}
