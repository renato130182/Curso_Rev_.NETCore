using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            // Menu inicial
            string op = ObterOp();
            while (!op.Equals("X"))
            {
                switch (op)
                {
                    case "1":
                        //TODO: adicionar aluno
                        Console.WriteLine("Informe o nome do aluno");
                        Aluno aluno = new Aluno();
                        aluno.nome = Console.ReadLine();
                        Console.WriteLine("Informe a nota do aluno");
                        // aluno.nota = decimal.Parse(Console.ReadLine()); dará erro se não for decimal
                        if(decimal.TryParse(Console.ReadLine(),out decimal nota)){
                            aluno.nota = nota;
                        }else{
                            throw new ArgumentException("Valor da nota deve ser decimal");
                        }
                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
                        break;
                    case "2":
                        //TODO: listar alunos
                        foreach(var a in alunos){
                            if(!string.IsNullOrEmpty(a.nome)){
                                Console.WriteLine($"ALUNO {a.nome} - NOTA {a.nota}");
                            }    
                        }
                        break;
                    case "3":
                        //TODO: Media geral
                        var nralunos=0;
                        decimal mediaGeral=0;
                        decimal notaTotal=0;
                        for(int i=0;i<alunos.Length;i++){
                            if(!string.IsNullOrEmpty(alunos[i].nome)){
                               notaTotal = notaTotal + alunos[i].nota;
                               nralunos++; 
                            }
                        }
                        mediaGeral = notaTotal/nralunos;
                        ConceitoEnum conceitogeral;
                        if(mediaGeral<=2){
                            conceitogeral = ConceitoEnum.E;
                        }else if(mediaGeral <=4){
                            conceitogeral = ConceitoEnum.D;
                        }else if(mediaGeral<=6){
                            conceitogeral = ConceitoEnum.C;
                        }else if(mediaGeral<=8){
                            conceitogeral = ConceitoEnum.B;
                        }else{
                            conceitogeral = ConceitoEnum.A;
                        }

                        Console.WriteLine($"Media Geral: {mediaGeral} conceito {conceitogeral}");
                        Console.WriteLine();
                        break;                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                op = ObterOp();
            }
        }

        private static string ObterOp()
        {
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Listar Alunos");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine();
            //Fim do menu inicial

            string op = Console.ReadLine(); // capturar opção digitada
            op = op.ToUpper();
            return op;
        }
    }
}
